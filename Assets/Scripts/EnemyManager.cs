using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Animator camAnim;
    private LevelContinueScript continueScript;
    void Awake()
    {
        continueScript = GameObject.FindGameObjectWithTag(Tags.CONTINUE_TRIGGER_TAG).GetComponent<LevelContinueScript>();
        camAnim = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<Animator>();
    }
    void Start()
    {
        enemiesLeft = true;    }
    private void Update() {
        if (GameObject.FindWithTag(Tags.ENEMY_TAG) == null && GameObject.FindWithTag(Tags.BOSS_TAG) == null)
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
                camAnim.SetTrigger("signAnimation");
                continueScript.canContinue = true;
                enemiesLeft = true;
            }
        }
        
    }

}
