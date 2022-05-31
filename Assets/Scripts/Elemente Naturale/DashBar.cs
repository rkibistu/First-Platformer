using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    private Image image;
    private Image imageBG;

    private float dashCooldown;
    
    void Start()
    {
        image = GetComponent<Image>();
        imageBG = transform.parent.GetComponent<Image>();
        dashCooldown = InputManager.Instance.GetDashCooldown();
    }

    
    void Update()
    {
        float dashCooldownTimer = InputManager.Instance.GetDashCooldownTimer();


        if (dashCooldownTimer <= 0) {

            imageBG.enabled = false;
            image.enabled = false;
        }
        else {

            image.enabled = true;
            imageBG.enabled = true;
            image.fillAmount =  dashCooldownTimer / dashCooldown;
        }
    }

}
