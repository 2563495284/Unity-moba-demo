using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

public class SkillJoystick : MonoBehaviour {
    
    public Action<Vector2> onJoystickDownEvent;     // 按下事件
    public Action onJoystickUpEvent;     // 抬起事件
    public Action<Vector3> onJoystickMoveEvent;     // 滑动事件
    public bool isDown=false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isDown = true;
            if (onJoystickDownEvent != null)
                onJoystickDownEvent(transform.position);
        }

        if (isDown==true&&onJoystickMoveEvent != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            Vector3 distance = hitInfo.point - transform.position;
            Debug.Log(hitInfo.point.x);
            onJoystickMoveEvent(hitInfo.point);
        }

        if (isDown==true&& Input.GetMouseButtonUp(0))
        {
            if (onJoystickUpEvent != null)
                onJoystickUpEvent();
            isDown = false;
        }
    }
}
