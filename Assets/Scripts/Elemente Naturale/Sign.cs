using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{

    private DialogueTrigger dialogueTrigger;

    private bool scrollable = false;
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void Update() {

        if (scrollable) {

            if (InputManager.Instance.attackButtonPressed) {

                dialogueTrigger.GoToNextSentence();
                InputManager.Instance.attackButtonPressed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {

            scrollable = true;
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {

            scrollable = false;
            DialogueManager.Instance.EndDialogue();
        }
    }



}
