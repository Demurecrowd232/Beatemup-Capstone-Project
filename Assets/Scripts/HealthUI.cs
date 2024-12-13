using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private HealthScript hpScript;
    private Image healthImage;
    void Start()
    {
        hpScript = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<HealthScript>();
        healthImage = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        healthImage.fillAmount = hpScript.health / 100f;
    }
}
