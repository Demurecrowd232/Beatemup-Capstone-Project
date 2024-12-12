using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContinueScript : MonoBehaviour
{
    public bool canContinue;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(Tags.PLAYER_TAG) && canContinue)
        {
            GetComponentInParent<Animator>().SetTrigger("cameraContinue");
            canContinue = false;
        }
    }
}
