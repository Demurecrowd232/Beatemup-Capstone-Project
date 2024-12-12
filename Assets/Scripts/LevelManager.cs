using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject continueTrigger;
    private GameObject cam;
    private Animator camAnim;
    public bool contin;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA_TAG);
        camAnim = cam.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            //Pause Menu
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            //play Camera Animation
            camAnim.SetTrigger("cameraContinue");
        }


    }


    public void Continue()
    {
        //Check for bool to be set then wait for trigger of box
        if (contin)
        {
            //Move to next slide
        }
    }

    public void PlayerIsDead()
    {
        //Lose Screen/Restart
    }
}
