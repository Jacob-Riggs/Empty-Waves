using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour {

    public Conversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private DialogueUI speakerUILeft;
    private DialogueUI speakerUIRight;

    private int activeLineIndex = 0;

	// Use this for initialization
	void Start () {

        speakerUILeft = speakerLeft.GetComponent<DialogueUI>();
        speakerUIRight = speakerRight.GetComponent<DialogueUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
	}

    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if(speakerUILeft.SpeakerIs(character))
        {
            SetDialogue(speakerUILeft, speakerUIRight, line.text);
        } else
        {
            SetDialogue(speakerUIRight, speakerUILeft, line.text);
        }

    }

    void SetDialogue(DialogueUI activeSpeakerUI, DialogueUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }

}
