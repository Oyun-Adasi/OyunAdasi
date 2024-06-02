using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScriptDin : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerDin quizManager;

    public void Answers()
    {
        if (isCorrect)
        {
            Debug.Log("CorrectAnswer");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("WrongAnswer");
            quizManager.Incorrect();
        }
    }

}
