﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour {

    public Question question;
    public Text questionText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    public void Change(Question _question)
    {
        RemoveChoices();
        question = _question;
        gameObject.SetActive(true);
        Initalize();
    }

    public void Hide(Conversation conversation)
    {
        gameObject.SetActive(false);
        RemoveChoices();
    }

    private void RemoveChoices()
    {
        foreach(ChoiceController c in choiceControllers) {
            Destroy(c.gameObject);

            choiceControllers.Clear();
        }
    }
	
    private void Initalize()
    {
        questionText.text = question.text;

        for(int index=0; index < question.choices.Length; index++)
        {
            ChoiceController c = ChoiceController.AddChoiceButton(choiceButton, question.choices[index], index);
            choiceControllers.Add(c);
        }

        choiceButton.gameObject.SetActive(false);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
