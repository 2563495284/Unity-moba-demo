using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public float maxHealth=5f;
    public float currentHealth;
    public PlayerState enemyState;
    private void Awake()
    {
        currentHealth = maxHealth;
        enemyState = PlayerState.Idle;
    }

    public void BeAttack(float damage)
    {
        currentHealth-=damage;
    }
}
