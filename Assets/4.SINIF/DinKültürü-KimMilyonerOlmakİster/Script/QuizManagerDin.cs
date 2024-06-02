using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManagerDin : MonoBehaviour
{
    public List<QuestionAndAnswerDin> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionText;

    public TextMeshProUGUI FeedbackText;
    public TextMeshProUGUI ScoreText;

    private int score = 0;

    private void Start()
    {
        if (QnA.Count > 0)
        {
            GenerateQuestion();
        }
        else
        {
            Debug.LogError("No questions available in the QnA list.");
        }
    }


    public void Correct()
    {
        score++;
        UpdateScore();
        FeedbackText.text = "Correct!";
        QnA.RemoveAt(currentQuestion);

        if (QnA.Count > 0)
        {
            GenerateQuestion();
        }
        else
        {
            Debug.Log("Quiz Finished");
            FeedbackText.text = "Quiz Finished! Your score: " + score;
        }
    }

    public void Incorrect()
    {
        FeedbackText.text = "Incorrect!";
        Debug.Log("Wrong Answer");

        if (QnA.Count > 0)
        {
            GenerateQuestion();
        }
        else
        {
            Debug.Log("Quiz Finished");
            FeedbackText.text = "Quiz Finished! Your score: " + score;
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScriptDin>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScriptDin>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else
        {
            Debug.LogError("No questions available to generate.");
        }
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }
}
