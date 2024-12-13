using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContinueScript : MonoBehaviour
{
    public bool canContinue;
    public LevelManager lvlMgmt;
    void Start ()
    {
        lvlMgmt = GameObject.FindGameObjectWithTag(Tags.LEVEL_MANAGER_TAG).GetComponent<LevelManager>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(Tags.PLAYER_TAG) && canContinue)
        {
            canContinue = false;
            lvlMgmt.Continue();
            GetComponentInParent<Animator>().SetTrigger("cameraContinue");
            
        }
    }
}
