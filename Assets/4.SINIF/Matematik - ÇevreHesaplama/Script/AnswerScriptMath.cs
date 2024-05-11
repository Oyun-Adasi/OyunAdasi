using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScriptMath : MonoBehaviour
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
