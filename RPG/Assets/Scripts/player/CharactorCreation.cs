using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorCreation : MonoBehaviour
{
    //获取资源中的角色预制体
    public GameObject[] charactorPrefabs;
    public GameObject[] CharactorGameObjects;
    private int selectIndex;
    private int length;

    private void Start()
    {
        length = charactorPrefabs.Length;
        CharactorGameObjects = new GameObject[length];
        //全部实例化
        for (int i = 0; i < length; i++)
        {
            CharactorGameObjects[i] = 
                GameObject.Instantiate(charactorPrefabs[i], transform.position, transform.rotation)as GameObject;
        }

        UpdateCharactorShow();
    }

    private void Update()
    {
    }

    void UpdateCharactorShow()
    {
        CharactorGameObjects[selectIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i!=selectIndex)
            {
                CharactorGameObjects[i].SetActive(false);
            }
        }
    }

    public void OnNextButton()
    {
        selectIndex++;
        selectIndex %= length;
        UpdateCharactorShow();
    }
    public void OnPrevButton()
    {
        selectIndex--;
        if (selectIndex==-1)
        {
            selectIndex = length-1;
        }

        UpdateCharactorShow();
    }

    public void OnOkButton()
    {
        //加载下一个场景
        //存储选择的角色
        PlayerPrefs.SetInt("selectCreationIndex",selectIndex);
        //存储输入的名字
        PlayerPrefs.SetString("name","张三");
    }
}
