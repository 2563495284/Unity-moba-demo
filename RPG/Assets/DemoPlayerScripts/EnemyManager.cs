using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager _instance;
    public List<GameObject> enemyList;
    public GameObject enemy;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        enemy = Resources.Load<GameObject>("Prefabs/charactor/Swordman");
        addEnemy();
    }

    public void addEnemy()
    {
       enemyList.Add(Instantiate(enemy, transform));
    }

    public void removeEnemy(GameObject enemyObj)
    {
        enemyList.Remove(enemyObj);
    }
}
