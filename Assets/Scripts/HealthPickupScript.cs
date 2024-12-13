using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public HealthScript playerHP;
    void Start()
    {
        player = GameObject.FindWithTag(Tags.PLAYER_TAG);
        playerHP = player.GetComponent<HealthScript>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == player)
        {
            playerHP.health = 100;
            Destroy(gameObject);
        }
    }
}
