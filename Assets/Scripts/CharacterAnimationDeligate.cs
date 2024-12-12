using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDeligate : MonoBehaviour
{
    public GameObject left_hand_attack_point, right_hand_attack_point, left_foot_attack_point, right_foot_attack_point, right_knee_attack_point;
    public float standUpTimer = 2f;
    private CharacterAnimations charAnim;
    private EnemyMovement enMov;

    void Awake()
    {
     charAnim = GetComponent<CharacterAnimations>();
     enMov = GetComponentInParent<EnemyMovement>();
    }
   void left_hand_attack_on()
   {
        left_hand_attack_point.SetActive(true);
   }
   void left_hand_attack_off()
   {
        if (left_hand_attack_point.activeInHierarchy)
        {
            left_hand_attack_point.SetActive(false);
        }
   }


   void right_hand_attack_on()
   {
        right_hand_attack_point.SetActive(true);
   }
   void right_hand_attack_off()
   {
        if (right_hand_attack_point.activeInHierarchy)
        {
            right_hand_attack_point.SetActive(false);
        }
   }

   
   void left_foot_attack_on()
   {
        left_foot_attack_point.SetActive(true);
   }
   void left_foot_attack_off()
   {
        if (left_foot_attack_point.activeInHierarchy)
        {
            left_foot_attack_point.SetActive(false);
        }
   }


   void right_foot_attack_on()
   {
        right_foot_attack_point.SetActive(true);
   }
   void right_foot_attack_off()
   {
        if (right_foot_attack_point.activeInHierarchy)
        {
            right_foot_attack_point.SetActive(false);
        }
   }


   void right_knee_attack_on()
   {
        right_knee_attack_point.SetActive(true);
   }
   void right_knee_attack_off()
   {
        if (right_knee_attack_point.activeInHierarchy)
        {
            right_knee_attack_point.SetActive(false);
        }
   }

     void TagLeft_Hand()
     {
          left_hand_attack_point.tag = Tags.LEFT_ARM_TAG;
     }
     void UntagLeft_Hand()
     {
          left_hand_attack_point.tag = Tags.UNTAGGED_TAG;
     }

     void TagRight_Hand(){
          right_hand_attack_point.tag = Tags.RIGHT_ARM_TAG;
     }
     void UntagRight_Hand(){
          right_hand_attack_point.tag = Tags.UNTAGGED_TAG;
     }

     void TagLeft_Leg()
     {
          left_foot_attack_point.tag = Tags.LEFT_LEG_TAG;
     }
     void UntagLeft_Leg()
     {
          left_foot_attack_point.tag = Tags.UNTAGGED_TAG;
     }

     void TagRight_Leg()
     {
          right_foot_attack_point.tag = Tags.RIGHT_LEG_TAG;
     }
     void UntagRight_Leg()
     {
          right_foot_attack_point.tag = Tags.UNTAGGED_TAG;
     }

     void TagRight_Knee()
     {
          right_knee_attack_point.tag = Tags.RIGHT_KNEE_TAG;
     }
     void UntRight_Knee()
     {
          right_knee_attack_point.tag = Tags.UNTAGGED_TAG;
     }

     void enemyStandup()
     {
          StartCoroutine(StandUpAfterTime());
     }
     IEnumerator StandUpAfterTime()
     {
          yield return new WaitForSeconds(standUpTimer);
          charAnim.Stand_Up();
          enMov.KnockedDown = false;
     }
}
