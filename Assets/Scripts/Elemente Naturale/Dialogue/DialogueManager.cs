using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    static public DialogueManager Instance { get; private set; }

    public Text titleText;
    public Text dialogueText;
    private Queue<string> sentences;

    public Animator animator;

    private void Awake() {
        
        Instance = this;

    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

        animator.SetBool("isOpen",true);

        titleText.text = dialogue.title;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public int DisplayNextSentence() {
        
        if(sentences.Count == 0) {

            EndDialogue();
            return -1;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        return 0;
    }

    IEnumerator TypeSentence(string sentence) {

        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()) {

            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {

        animator.SetBool("isOpen", false);
    }

}
