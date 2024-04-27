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

    private void Start()
    {
        GenerateQuestion();
    }

    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
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
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionText.text = QnA[currentQuestion].Question;

        SetAnswers();
    }
}
