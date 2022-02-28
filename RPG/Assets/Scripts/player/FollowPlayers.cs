using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public  class FollowPlayers : MonoBehaviour
{
    private Transform player;
    //相机与角色位置偏移
    private Vector3 offsePosition;
    //相机缩放速度
    public float scrollSpeed = 4f;
    //相机旋转速度
    public float rotateSpeed = 1f;
    public float distance = 0;
    //是否开启滑动
    private bool isRotate;
    void Start()
    {
        player = GameObject.FindWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsePosition = transform.position - player.position;
    }
    void Update()
    {
        transform.position = offsePosition + player.position;
        //处理视野旋转
        RotateView();
        //处理屏幕滑动
        ScrollView();
    }

    void ScrollView()
    {
        //前正后负
        distance = offsePosition.magnitude;
        distance-=Input.GetAxis("Mouse ScrollWheel")*scrollSpeed;
        distance = Mathf.Clamp(distance,2f,18f);
        offsePosition = offsePosition.normalized*distance;
    }

    void RotateView()
    {
        //Input.GetAxis("Mouse X");//得到鼠标x轴方向移动
        //Input.GetAxis("Mouse Y");//得到鼠标y轴方向移动
        if (Input.GetMouseButtonDown(0))
        {
            isRotate = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotate = false;
        }

        if (isRotate)
        {
            transform.RotateAround(player.position,player.up, rotateSpeed*Input.GetAxis("Mouse X"));
            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position,transform.right,-rotateSpeed*Input.GetAxis("Mouse Y"));
            float x = transform.eulerAngles.x;
            if (x<10||x>65)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
        }
        offsePosition = transform.position - player.position;
    }
}

