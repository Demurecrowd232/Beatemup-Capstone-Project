using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}
public class player1Combat : MonoBehaviour
{
    private CharacterAnimations player_Anim;
    private bool  activateResetTimer;
    private float def_Timer = 1.2f;
    private float curr_Timer;
    private ComboState curr_ComboState;
    void Start()
    {
        curr_Timer = def_Timer;
        curr_ComboState = ComboState.NONE;
    }
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks(); 
        ResetComboState();
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (curr_ComboState == ComboState.PUNCH_3 || 
                curr_ComboState == ComboState.KICK_1 || 
                curr_ComboState == ComboState.KICK_2)
            {
                return;
            }
            curr_ComboState++;
            activateResetTimer = true;
            curr_Timer = def_Timer;
            if (curr_ComboState == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }
            if (curr_ComboState == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }
            if(curr_ComboState == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (curr_ComboState == ComboState.PUNCH_3 || 
                curr_ComboState == ComboState.KICK_2)
            {
                return;
            }
            
            if (curr_ComboState == ComboState.NONE || 
                curr_ComboState == ComboState.PUNCH_1 ||
                curr_ComboState == ComboState.PUNCH_2)
                {
                    curr_ComboState = ComboState.KICK_1;
                } else if (curr_ComboState == ComboState.KICK_1)
                {
                    curr_ComboState++;
                }
                activateResetTimer = true;
                curr_Timer = def_Timer;

                if (curr_ComboState == ComboState.KICK_1)
                {
                    player_Anim.Kick_1();
                }
                if (curr_ComboState == ComboState.KICK_2)
                {
                    player_Anim.Kick_2();
                }

        }
    }

    void ResetComboState()
    {
        if (activateResetTimer)
        {
            curr_Timer -= Time.deltaTime;
            if (curr_Timer <= 0f)
            {
                curr_ComboState = ComboState.NONE;
                activateResetTimer = false;
                curr_Timer = def_Timer;
            }
        }
    }
}
