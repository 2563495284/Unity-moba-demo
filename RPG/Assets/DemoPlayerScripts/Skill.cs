using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using Debug = UnityEngine.Debug;
public enum SkillType
{
    buff,
    damage
}
public class Skill : MonoBehaviour
{
    public Action<Vector2> onJoystickDownEvent;     // Q
    public Action onJoystickUpEvent;     // 移动
    public Action<Vector3> onJoystickMoveEvent;     // 右键
    public Player player;
    public SkillArea skillArea;
    public List<SkillProperty> skillList;
    public bool isSkilling = false;
    // 技能的图标
    public Image icon0;
    public Image icon1;
    public Image icon2;
    public Image icon3;
    //射线
    private RaycastHit hitInfo;
    void beIdle()
    {
        PlayerStates.toBeIdle();
        isSkilling = false;
    }
    void Start()
    {
        skillArea = transform.GetComponent<SkillArea>();
        player = transform.GetComponent<Player>();
        skillList = new List<SkillProperty>(4);
        SkillProperty skillProperty0 = new SkillProperty(3f,SkillType.damage,SkillAreaType.OuterCircle_InnerCircle,PlayerState.Attack1,icon0,SkillEffect.Q,2f);
        SkillProperty skillProperty1 = new SkillProperty(5f,SkillType.buff,SkillAreaType.OuterCircle,PlayerState.Skill_GroundImpact,icon1,SkillEffect.W,1f);
        SkillProperty skillProperty2 = new SkillProperty(1f,SkillType.damage,SkillAreaType.OuterCircle_InnerCircle,PlayerState.Attack2,icon2,SkillEffect.E,1f);
        SkillProperty skillProperty3 = new SkillProperty(8f,SkillType.damage,SkillAreaType.OuterCircle_InnerCube, PlayerState.Skill_MagicBall,icon3,SkillEffect.R,4f);
        skillList.Add(skillProperty0);
        skillList.Add(skillProperty1);
        skillList.Add(skillProperty2);
        skillList.Add(skillProperty3);
        Debug.Log(skillList[0]);
        Debug.Log(skillList[1]);
        Debug.Log(skillList[2]);
        Debug.Log(skillList[3]);
    }

    void UserSkil( ref float currentCoolDown,float coolDown,Vector3 pos,SkillAreaType areaType,SkillEffect skillEffect,float damage)
    {
        Vector2 absPos = new Vector2(pos.x-transform.position.x, pos.z-transform.position.z);
        absPos = absPos.magnitude <= 6 ? absPos : absPos.normalized * 6;
        pos = new Vector3(absPos.x+transform.position.x, transform.position.y, absPos.y+transform.position.z);
        if (currentCoolDown >= coolDown)
        {
            switch (skillEffect)
            {
                case SkillEffect.Q: EffectsManager._instance.ShowSkillEffect(SkillEffect.Q,pos);
                    break;
                case SkillEffect.W: EffectsManager._instance.ShowSkillEffect(SkillEffect.W,transform.position);
                    break;
                case SkillEffect.E: EffectsManager._instance.ShowSkillEffect(SkillEffect.E,pos);
                    break;
             case SkillEffect.R: EffectsManager._instance.ShowSkillEffect(SkillEffect.R,transform.position);
                 break;
            }
            foreach (var enemy in EnemyManager._instance.enemyList)
            {
                bool inArea = false;
                switch (areaType)
                {
                    case SkillAreaType.OuterCircle :
                        inArea = isOnRange(transform.position, enemy.transform, 6f); break;
                    case SkillAreaType.OuterCircle_InnerCircle :
                        inArea = isOnRange(pos, enemy.transform, 2f);
                        break;
                    case SkillAreaType.OuterCircle_InnerCube :
                        inArea = isOnRange(transform, enemy.transform.position, 2f, 6f);
                        break;
                    case SkillAreaType.OuterCircle_InnerSector : 
                        inArea = isOnRange(transform, enemy.transform, 60, 6f);
                        break;
                }
                if (inArea)
                {
                    enemy.GetComponent<EnemyProperty>().BeAttack(damage);
                }
            }
            // 重置冷却时间
            currentCoolDown = 0;
            Invoke("beIdle",0.83f);
        }
    }

    #region 范围判定
    bool isOnRange(Transform player,Transform enemy,float angle,float radius)
    {
        Vector3 delta = player.position - enemy.position;
        delta = toBePos(delta);
        float tmpAngle = Mathf.Acos(Vector3.Dot(delta.normalized,player.forward)) * Mathf.Deg2Rad;
        if (tmpAngle<=angle*0.5f&& delta.magnitude<=radius)
        {
            return true;
        }
        return false;
    }
    bool isOnRange(Vector3 player,Transform enemy,float radius)
    {
        Vector3 delta = player - enemy.position;
        delta = toBePos(delta);
        if (delta.magnitude<=radius)
        {
            return true;
        }
        return false;
    }
    bool isOnRange(Transform player,Vector3 enemy, float wide,float length)
    {

        Vector3 aPos = player.right*wide/2+player.position;
        Vector3 bPos = -player.right*wide/2+player.position;
        Vector3 cPos = aPos + player.forward * length;
        Vector3 dPos = bPos + player.forward * length;
        aPos = toBePos(aPos);
        bPos = toBePos(bPos);
        cPos = toBePos(cPos);
        dPos = toBePos(dPos);
        enemy = toBePos(enemy);
        if (Vector3.Dot(Vector3.Cross((cPos - aPos), (enemy - aPos)) ,Vector3.Cross((bPos - dPos), (enemy - dPos)))>=0&&
            Vector3.Dot(Vector3.Cross((aPos - bPos), (enemy - bPos)) ,Vector3.Cross((dPos - cPos), (enemy - cPos)))>=0
            )
        {
            return true;   
        }
        return false;
    }
    #endregion
    Vector3 toBePos(Vector3 pos)
    {
        return new Vector3(pos.x, 0, pos.z);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectSkill(skillList[0]);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectSkill(skillList[1]);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectSkill(skillList[2]);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SelectSkill(skillList[3]);
        }
        foreach (var skill in skillList)
        {
            if (skill.isSkill==true&&onJoystickMoveEvent != null)
            {
                GetHitInfo(ref hitInfo);
                onJoystickMoveEvent(hitInfo.point);
            }
            if (skill.isSkill==true&& Input.GetMouseButtonUp(0))
            {
                if (onJoystickUpEvent != null)
                    onJoystickUpEvent();
                skill.isSkill = false;
                PlayerStates.state = skill.playerState;
                GetHitInfo(ref hitInfo);
                transform.LookAt(new Vector3(hitInfo.point.x,transform.position.y,hitInfo.point.z));
                UserSkil(ref skill.currentCoolDown,skill.coolDown,hitInfo.point,skillArea.areaType,skill.skillEffect,skill.damage);
            }   
        }
        //施法取消
        if (isSkilling==true&& Input.GetMouseButtonUp(1))
        {
            GetHitInfo(ref hitInfo);
            if (onJoystickUpEvent != null)
                onJoystickUpEvent();
            isSkilling=skillList[0].isSkill=skillList[1].isSkill=skillList[2].isSkill=skillList[3].isSkill= false;
            player.LookAtTarget(hitInfo.point);
        }

        foreach (var skill in skillList)
        {
            ReduceCD(ref skill.currentCoolDown, skill.coolDown,skill.icon);
        }
    }
    //选择技能
    void SelectSkill(SkillProperty skill)
    {
        if (skill.currentCoolDown >= skill.coolDown&&isSkilling==false)
        {
            PlayerStates.state = PlayerState.Idle;
            skillArea.areaType = skill.skillAreaType;
            skill.isSkill= isSkilling = true;
            if (onJoystickDownEvent != null)
                onJoystickDownEvent(transform.position);
        }
    }
    //获取鼠标与地板交互位置
    void GetHitInfo(ref RaycastHit hitInfo)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitInfo);
    }
    //每帧CD刷新
    void ReduceCD(ref float currentCoolDown, float coolDown,Image icon)
    {
        if (currentCoolDown < coolDown)
        {
            // 更新冷却
            currentCoolDown += Time.deltaTime;
            // 显示冷却动画
            icon.fillAmount=currentCoolDown / coolDown;
        }
    }
}

