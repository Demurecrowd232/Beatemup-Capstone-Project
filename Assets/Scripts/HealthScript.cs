using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimations characterAnim;
    private AnimationDeligate animationDeligate;

    private EnemyMovement enMov;
    public EnemyManager Spawner;
    private LevelManager lvlMgmt;
    private bool characterDied;
    public bool isPlayer, isEnemy1, isEnemy2, isBoss;

    void Awake() 
    {
        characterAnim = GetComponentInChildren<CharacterAnimations>();
        animationDeligate = GetComponentInChildren<AnimationDeligate>();
        enMov = GetComponent<EnemyMovement>();
        lvlMgmt = GameObject.FindWithTag(Tags.LEVEL_MANAGER_TAG).GetComponent<LevelManager>();

        if (isPlayer)
        {
            //blank
        }
        else if (isEnemy1)
        {
            Spawner = GameObject.FindWithTag("EnemySpawner1").GetComponent<EnemyManager>();
        }
        else if (isEnemy2)
        {
            Spawner = GameObject.FindWithTag("EnemySpawner2").GetComponent<EnemyManager>();
        }
        else
        {
            //blank
        }
    }
   public void ApplyDamage(float damage, bool knockDown)
   {
        if (characterDied)
        {
            return;
        }
        
        health -= damage;

        if (health <= 0)
        {
            characterAnim.Death();
            characterDied = true;

            if (isPlayer)
            {
                //Add in Death Screen Trigger Here
                lvlMgmt.PlayerIsDead();

            }
            else
            {
                enMov.enabled = false;
                CharacterDied();
                
            }

            
            return;
        }
        if (!isPlayer && !isBoss)
            {
                if (knockDown)
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        characterAnim.Knock_Down();
                        gameObject.GetComponentInParent<EnemyMovement>().KnockedDown = true;
                    }
                    else
                    {
                        if (Random.Range(0, 3) > 1)
                        {
                            characterAnim.Hit();
                        }
                    }
                }
            }

            if (isPlayer)
            {
                if (knockDown)
                {
                    //THIS NEEDS WORK ANIMATIONS CUT OVER KNOCKDOWN AND GETUP
                    if (Random.Range(0, 4) > 3)
                    {
                        characterAnim.Knock_Down();
                    }
                    else
                    {
                        if (Random.Range(0, 3) > 2)
                        {
                            characterAnim.Hit();
                        }
                    }
                }
            }
            
            if (isBoss)
            {
               
                    
                if (Random.Range(0, 3) > 2)
                {
                    characterAnim.Hit();
                }
                    
                
            }
   }

   public void CharacterDied()
     {
          Invoke("DeactivateGameObject", 2f);
     }
     void DeactivateGameObject()
     {
        if (isEnemy1 || isEnemy2)
        {
            Spawner.SpawnEnemy();
        }
        //gameObject.SetActive(false);
        Destroy(gameObject);
     }
}
