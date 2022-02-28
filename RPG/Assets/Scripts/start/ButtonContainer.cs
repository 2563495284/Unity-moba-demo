using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour
{
    //开始新游戏
    public void OnNewGame()
    {
        PlayerPrefs.SetInt("DataFromSave",1);
        //加载选择角色场景
    }
    //加载游戏
    public void OnLoadGame()
    {
        //DataFromSave数据来自保存
        PlayerPrefs.SetInt("DataFromSave",1);
    }
}
