using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Adic;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public CommandReference buttonCommand;

    public AudioClip clip;
    private Vector3 position;


    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Queue<string> sentences;


    void Start() {
        position = transform.position;
        sentences = new Queue<string>();
    }

    protected void DispatchCommand()
    {
        AudioSource.PlayClipAtPoint(clip, position);
        this.buttonCommand.DispatchCommand(dialogue, animator, nameText, dialogueText, sentences); // Dispatch the command chosen for button with passed data.
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }

}
