using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNPC : NPC
{
    public GameObject quest;
    public bool isShowQuest = false;
    public Text Text;
    private void Start()
    {
        
    }

    //当鼠标位于collider之上时，会每帧调用
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)&&!isShowQuest)
        {
            ShowQuest();
        }
    }

    void ShowQuest()
    {
        quest.SetActive(true);
        isShowQuest = true;
    }

   public void closeQuest()
    {
        quest.SetActive(false);
        isShowQuest = false;
    }
}
