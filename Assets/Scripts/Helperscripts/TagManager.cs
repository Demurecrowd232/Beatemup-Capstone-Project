using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationTags
{
    public const string MOVEMENT = "Movement";
    public const string PUNCH_1_TRIGGER = "Punch1";
    public const string PUNCH_2_TRIGGER = "Punch2";
    public const string PUNCH_3_TRIGGER = "Punch3";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";

    
    public const string SPECIAL_1_TRIGGER = "Special1";
    public const string SPECIAL_2_TRIGGER = "Special2";
    public const string SPECIAL_3_TRIGGER = "Special3";

    public const string IDLE_ANIMATION = "Idle";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string STAND_UP_TRIGGER = "StandUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";

    public const string ATTACK_1_TRIGGER = "Attack1";
    public const string ATTACK_2_TRIGGER = "Attack2";
    public const string ATTACK_3_TRIGGER = "Attack3";

}
public class Axis {
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags
{
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string LEFT_ARM_TAG = "LeftArm";
    public const string RIGHT_ARM_TAG = "RightArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string RIGHT_LEG_TAG = "RightLeg";
    public const string RIGHT_KNEE_TAG = "RightKnee";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI_TAG = "HealthUI";
    public const string CONTINUE_TRIGGER_TAG = "ContinueWallTrigger";
}

/*
Controls so far:
WASD MOVE
J Punch
K Kick
L Special

COMBOS
J Punch
JJ Double Punch
JJJ Triple Punch
K Kick
KK Double Kick
JK Punch + Kick
JJK Double Punch + Kick
JKK Punch + Double Kick
JJKK Double Punch + Double Kick
*/ 