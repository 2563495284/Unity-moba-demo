using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerControl
{
    public float speedPlayer = 4f;//初始化速度
    private GameObject effect_mouse_click;
    public CharacterController characterController;
    public Skill skill;
    //判断是否移动
    void Start()
    {
        characterController = transform.GetComponent<CharacterController>(); 
        targetPos = transform.position;
        skill = transform.GetComponent<Skill>();
        effect_mouse_click = Resources.Load<GameObject>("Effect/Efx_Click_Green");//获取按钮点击特效
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider&& hitInfo.collider.tag==Tags.ground)
            {
                isMoving = true;
                ShowEffect(effect_mouse_click,hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMoving = false;
        }
        if (isMoving)
        {
            LookAtTarget(targetPos);
        }
        float distance = Vector3.Distance(targetPos,transform.position);
        if ((distance>0.3)&& !skill.isSkilling)
        {
            isMoving = true;
            PlayerStates.state = PlayerState.Run;
            characterController.SimpleMove(transform.forward * speedPlayer);
        }
        else if(!skill.isSkilling)
        {
            isMoving = false;
            PlayerStates.toBeIdle();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            targetPos = transform.position;
            PlayerStates.toBeIdle();
        }
    }
}
