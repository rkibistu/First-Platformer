using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightDialogue : MonoBehaviour {


    public BossStateMachine m_sm;
    
    public DialogueTrigger m_firstDialogue;
    public DialogueTrigger m_secondDialogue;

    public WifeController m_wife;

    private bool start = true;
    private bool scrollable1 = false;
    private bool end = false;
    void Start() {

        scrollable1 = true;
    }

    
    void Update() {
        if (start) {
            // daca pun in Start() nu merge. variabila Dialogue din trigger e inca nula.
            m_firstDialogue.TriggerDialogue();
            start = false;
        }

        if (scrollable1) {

            if (InputManager.Instance.attackButtonPressed) {

                if(m_firstDialogue.GoToNextSentence() == -1) {

                    m_sm.m_startMoving = true;
                    scrollable1 = false;
                }
            }
        }
        
        if(m_sm.m_currentHealth <= 0 && !end) {

            end = true;
            m_wife.WifeGoVisible();
            Invoke("EndOfLevel", 2.4f);
        }
    }
    private void EndOfLevel() {
        m_secondDialogue.TriggerDialogue();
        Invoke("NextLevel", 5);
    }
    private void NextLevel() {

        LevelLoader.Instance.LoadNextLevel();
    }
}
