using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;
    public bool isPlayer, isEnemy;
    public GameObject hitFX_Prefab;

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        //test code
        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                Vector3 hitfx_Pos = hit[0].transform.position;
                hitfx_Pos.y += 0f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitfx_Pos.x += .2f;
                }

                else if (hit[0].transform.forward.x < 0)
                {
                    hitfx_Pos.x -= .2f;
                }

                Instantiate(hitFX_Prefab, hitfx_Pos, Quaternion.identity);

                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else 
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }

            if (!isPlayer)
            {
                Vector3 hitfx_Pos = hit[0].transform.position;
                hitfx_Pos.y += 0f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitfx_Pos.x -= .2f;
                }

                else if (hit[0].transform.forward.x < 0)
                {
                    hitfx_Pos.x += .2f;
                }

                Instantiate(hitFX_Prefab, hitfx_Pos, Quaternion.identity);

                if(gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else 
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }

            gameObject.SetActive(false);
        }
    }
}
