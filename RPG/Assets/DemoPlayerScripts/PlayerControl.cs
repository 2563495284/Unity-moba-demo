using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public Vector3 targetPos=Vector3.zero;//目标位置
    //判断是否移动
    public bool isMoving=false;
    /// <summary>
    /// 播放特效
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="target"></param>
    public void ShowEffect(GameObject obj, Vector3 target)
    {
        target = new Vector3(target.x, target.y + 0.1f, target.z);
        Instantiate(obj, target, Quaternion.identity);
    }
    /// <summary>
    /// 主角看向目标位置（x，z）变化y不变。
    /// </summary>
    /// <param name="target"></param>
    public void LookAtTarget(Vector3 target)
    {
        targetPos = new Vector3(target.x, transform.position.y, target.z);
        transform.LookAt(targetPos);
    }
}
