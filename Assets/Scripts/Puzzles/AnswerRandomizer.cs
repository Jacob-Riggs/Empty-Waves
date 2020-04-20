using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperRandom
{
    // The purpose of this function is to allow for pieces of a puzzle to have one easy randomizer instead of writing something each time, and to not have conflicting names.
    public class Random
    {
        // Though to do so, we do need to use the system's random function to help.
        public System.Random rng = new System.Random();

        // This function will take our vlues in our list and mix them up for each value we have so that each one gets moved.
        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}

public class AnswerRandomizer : MonoBehaviour {

    /*
    public GameObject answerOne;
    public GameObject answerTwo;
    public GameObject answerThree;
    public GameObject answerFour;
    */

    public List<GameObject> answers;
    public List<GameObject> answerPoints;

    public SuperRandom.Random shuffleAnswers = new SuperRandom.Random();

    // Use this for initialization
    void Start () {

        // First, we shuffle our answers.
        shuffleAnswers.Shuffle(answers);
        
        Debug.Log(answers[3]);

	}
	
	// Update is called once per frame
	void Update () {
		
        // Then, while we have answers and answer points, we will take the last answer and answer point and put instantiate them, and then remove them.
        while(answers.Count > 0 && answerPoints.Count > 0)
        {
            GameObject answer = answers[answers.Count - 1];
            GameObject spawn = answerPoints[answerPoints.Count - 1];

            Instantiate(answer, spawn.transform);

            answers.RemoveAt(answers.Count - 1);
            answerPoints.RemoveAt(answerPoints.Count - 1);

        }

	}

}
