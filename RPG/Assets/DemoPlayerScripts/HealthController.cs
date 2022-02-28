using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    
    public EnemyProperty enemyProperty;
    public float fadeHealth;
    public GameObject sliderObj;
    public Slider slider;
    //1000 
    // Use this for initialization
    void Start ()
    {
        sliderObj = transform.Find("Canvas/Slider").gameObject;
        slider = sliderObj.GetComponent<Slider>();
        enemyProperty = transform.GetComponent<EnemyProperty>();
        slider.maxValue = enemyProperty.maxHealth;
        slider.value = enemyProperty.currentHealth;
        fadeHealth = enemyProperty.currentHealth;
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (enemyProperty.currentHealth>= enemyProperty.maxHealth)
        {
            enemyProperty.currentHealth = enemyProperty.maxHealth;
        }
        if (enemyProperty.currentHealth<=0)
        {
            enemyProperty.currentHealth = 0;
        }

        if (enemyProperty.currentHealth<fadeHealth)
        {
            fadeHealth -= Time.deltaTime*1f;
        }
        else
        {
            fadeHealth = enemyProperty.currentHealth;
        }
        slider.value = fadeHealth;
        if (enemyProperty.currentHealth==0)
        {
            enemyProperty.enemyState = PlayerState.Death;
        }

        if (fadeHealth==0)
        {
            sliderObj.SetActive(false);
            EnemyManager._instance.removeEnemy(gameObject);
        }
    }
}