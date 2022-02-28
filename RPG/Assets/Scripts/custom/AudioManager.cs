using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //按钮点击声效
    public AudioClip buttonDown;
    public AudioClip questButton;
    public AudioSource audioSource;

    private void Start()
    {
       audioSource=gameObject.GetComponent<AudioSource>();
        buttonDown = Resources.Load<AudioClip>("Sounds/button");
        questButton = Resources.Load<AudioClip>("Sounds/sfx_nextDialog");
    }

    public void ButtonDown()
    {
        audioSource.clip = buttonDown;
        audioSource.Play();
    }
    public void QuestButtonDown()
    {
        audioSource.clip = questButton;
        audioSource.Play();
    }
}
