using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour
{
    /*public GameObject effect_click_prefabs;
    public bool isMoving = false;//表示鼠标是否按下
    public Vector3 targetPosition=Vector3.zero;
    private PlayerMove _playerMove;
    private void Start()
    {
        _playerMove = this.GetComponent<PlayerMove>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider&&hitInfo.collider.tag==Tags.ground)
            {
                isMoving = true;
                //实例化出来点击效果
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            //得到要移动的目标位置，主角朝向位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider&&hitInfo.collider.tag==Tags.ground)
            {
               LookAtTarget(hitInfo.point);
            }
        }else if (_playerMove.isMoving)
        {
            LookAtTarget(targetPosition);
        }
    }

    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y+0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefabs, hitPoint, Quaternion.identity);
    }
    //主角看向
    void LookAtTarget(Vector3 target)
    {
        targetPosition = target;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        transform.LookAt(targetPosition);
    }*/
}
