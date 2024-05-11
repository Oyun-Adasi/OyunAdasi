using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManagerMath : MonoBehaviour
{
    public List<QuestionAndAnswerMath> QnA;
    public TMP_InputField inputField;
    public int currentQuestion;

    public Image QuestionImage;

    private void Start()
    {
        GenerateQuestion();
    }

    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void GenerateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionImage.sprite = QnA[currentQuestion].Question;

        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void CheckAnswer()
    {
        string userAnswer = inputField.text.Trim().ToLower();
        string correctAnswer = QnA[currentQuestion].CorrectAnswer.ToString(); // Doğru cevabın indeksini string olarak al

        if (userAnswer == correctAnswer)
        {
            Debug.Log("Correct Answer!");
            Correct();
        }
        else
        {
            Debug.Log("Wrong Answer! Try again.");
        }
    }

}
