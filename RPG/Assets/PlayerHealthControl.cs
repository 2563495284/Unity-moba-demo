using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthControl : MonoBehaviour
{
    public PlayerProperty playerProperty;
    public float fadeHealth;
    public GameObject sliderObj;
    public Slider slider;
    //1000 
    // Use this for initialization
    void Start ()
    {
        sliderObj = transform.Find("Canvas/Slider").gameObject;
        slider = sliderObj.GetComponent<Slider>();
        playerProperty = transform.GetComponent<PlayerProperty>();
        slider.maxValue = playerProperty.maxHealth;
        slider.value = playerProperty.currentHealth;
        fadeHealth = playerProperty.currentHealth;
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (playerProperty.currentHealth>= playerProperty.maxHealth)
        {
            playerProperty.currentHealth = playerProperty.maxHealth;
        }
        if (playerProperty.currentHealth<=0)
        {
            playerProperty.currentHealth = 0;
        }

        if (playerProperty.currentHealth<fadeHealth)
        {
            fadeHealth -= Time.deltaTime*1f;
        }
        else
        {
            fadeHealth = playerProperty.currentHealth;
        }
        slider.value = fadeHealth;
        if (playerProperty.currentHealth==0)
        {
            PlayerStates.state = PlayerState.Death;
        }

        if (fadeHealth==0)
        {
            sliderObj.SetActive(false);
        }
    }
}
