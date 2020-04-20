using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Adic;

public class DialogueManager : Adic.Command {

    /*
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public AudioClip clip;
    private Vector3 position;
    */
    private Queue<string> sentences;
    

	// Use this for initialization
	void Start () {
        
        //position = transform.position;
    }

    // There will only be one of these running at once, so singleton command was chosen.
    public override bool singleton { get { return true; } }

    // Inject needed depencies to run the dialogue
    [Inject]
    public Dialogue dialogue;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Queue<string> injectSentences;

    public override void Execute(params object[] parameters)
    {
        // Set needed depencies in order to be passed in as parameters.
        this.dialogue = (Dialogue)parameters[0];
        this.animator = (Animator)parameters[1];
        this.nameText = (Text)parameters[2];
        this.dialogueText = (Text)parameters[3];
        this.injectSentences = (Queue<string>)parameters[4];

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        injectSentences.Clear();

        
        foreach (string sentence in dialogue.sentences)
        {
            injectSentences.Enqueue(sentence);
        }
        //AudioSource.PlayClipAtPoint(clip, position);
        Thread dialogueThread = new Thread(DisplayNextSentence);
        //dialogueThread.Start();
        DisplayNextSentence();
    }
    
    /*
    public void StartDialogue(Dialogue dialogue) {

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        //AudioSource.PlayClipAtPoint(clip, position);
        Thread dialogueThread = new Thread(DisplayNextSentence);
        DisplayNextSentence();

    }
    */

    public void DisplayNextSentence() {
        if (injectSentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = injectSentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue() {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }

}
