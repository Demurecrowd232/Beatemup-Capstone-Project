using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private HealthScript hpScript;
    private Image healthImage;
    void Start()
    {
        hpScript = GameObject.FindWithTag(Tags.BOSS_TAG).GetComponent<HealthScript>();
        healthImage = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (GameObject.FindWithTag(Tags.BOSS_TAG) != null)
        {
            healthImage.fillAmount = hpScript.health / 100f;
        }
        else 
        {
            Destroy(GameObject.FindGameObjectWithTag("BossHealthBar"));
        }
    }
}
