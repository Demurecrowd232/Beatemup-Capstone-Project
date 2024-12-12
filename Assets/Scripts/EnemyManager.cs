using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public static EnemyManager instance;
    public int maxEnemySpawnNumber;
    private int actualEnemiesSpawned = 0;
    private LevelManager lvlMgmt;
    private bool enemiesLeft;

    [SerializeField]
    public GameObject enemyPrefab;
    private LevelContinueScript continueScript;
    void Awake()
    {
        continueScript = GameObject.FindGameObjectWithTag(Tags.CONTINUE_TRIGGER_TAG).GetComponent<LevelContinueScript>();
    }
    void Start()
    {
        //SpawnEnemy();
        enemiesLeft = true;
    }
    private void Update() {
        if (GameObject.FindWithTag(Tags.ENEMY_TAG) == null)
        {
            enemiesLeft = false;
            SpawnEnemy();
        }
    }
    public void SpawnEnemy()
    {
        if (actualEnemiesSpawned < maxEnemySpawnNumber)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            actualEnemiesSpawned ++;
        }
        else if(actualEnemiesSpawned >= maxEnemySpawnNumber)
        {
            if (enemiesLeft == false)
            {
                
                Debug.Log("CONTINUE GAME");
                //UI GO FORWARD ELEMENT APPEARS
                continueScript.canContinue = true;
                enemiesLeft = true;
            }
        }
        
    }

}
