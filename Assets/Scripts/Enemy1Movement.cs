using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimations enemyAnim;
    private Rigidbody rigBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attackDistance = 1f;
    private float chasePlayerAfterAttack = 1f;

    private float currentAttackTime;
    private float defaultAttackTime = 2f;

    private bool followPlayer, attackPlayer;
    
    [HideInInspector]
    public bool KnockedDown;

    void Awake()
    {

        enemyAnim = GetComponentInChildren<CharacterAnimations>();
        rigBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;

    }

    void Update()
    {
        Attack();
        
    }
    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!followPlayer)
        {
            return;
        }
        if(KnockedDown)
        {
            return;
        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            Vector3 dir = Quaternion.LookRotation(playerTarget.position - transform.position).eulerAngles;
            dir.x = 0;
            transform.rotation = Quaternion.Euler(dir);

            rigBody.velocity = transform.forward * speed;
            if (rigBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            rigBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }
    void Attack()
    {
        if (!attackPlayer)
        {
            return;
        }
        if (KnockedDown)
        {
            return;
        }

        currentAttackTime += Time.deltaTime;

        if (currentAttackTime > defaultAttackTime)
        {
            Vector3 dir = Quaternion.LookRotation(playerTarget.position - transform.position).eulerAngles;
            dir.x = 0;
            transform.rotation = Quaternion.Euler(dir);
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            currentAttackTime = 0f;
            
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
