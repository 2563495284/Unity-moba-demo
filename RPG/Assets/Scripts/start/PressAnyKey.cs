using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    //表示是否有按键按下;
    private bool isAnyKeyDown = false;

    private GameObject botton;
    // Start is called before the first frame update
    void Start()
    {
        //初始化botton
        botton = gameObject.transform.parent.Find("ButtonContainer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnyKeyDown==false)
        {
            if (Input.anyKey)
            {
                ShowButton();
            }
        }
    }

    void ShowButton()
    {
        botton.SetActive(true);
        gameObject.SetActive(false);
        isAnyKeyDown = true;
    }
}
