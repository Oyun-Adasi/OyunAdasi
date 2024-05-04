using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScriptTR : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerTR quizManagerTR;

    public void Answers()
    {
        if (isCorrect)
        {
            Debug.Log("CorrectAnswer");
            quizManagerTR.Correct();
        }
        else
        {
            Debug.Log("WrongAnswer");
            quizManagerTR.Correct();
        }
    }
}
