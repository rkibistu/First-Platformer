using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour {
    public BossStateMachine m_sm;

    private Image image;
    private Image imageBG;

    void Start() {
        image = GetComponent<Image>();
        imageBG = transform.parent.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update() {
        if (m_sm.m_currentHealth == 0)
            image.fillAmount = 0;
        else {
            
            image.fillAmount = m_sm.m_currentHealth / (float)m_sm.m_maxHealth;
        }
    }
}
