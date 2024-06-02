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
    public TextMeshProUGUI scoreText; // Add a reference to TextMeshProUGUI for the score
    public TextMeshProUGUI finalScoreText; // Add a reference to TextMeshProUGUI for the final score

    private int score = 0; // Variable to track the player's score

    private void Start()
    {
        GenerateQuestion();
        UpdateScoreText(); // Initialize the score display
        finalScoreText.gameObject.SetActive(false); // Hide final score text at the start
    }

    public void Correct()
    {
        score++; // Increment score
        UpdateScoreText(); // Update the score display
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Incorrect()
    {
        score--; // Decrement score
        UpdateScoreText(); // Update the score display
        Debug.Log("Wrong Answer! Try again.");
    }

    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionImage.sprite = QnA[currentQuestion].Question;

            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }
        else
        {
            Debug.Log("No more questions available.");
            ShowFinalScore();
        }
    }

    public void CheckAnswer()
    {
        string userAnswer = inputField.text.Trim().ToLower();
        string correctAnswer = QnA[currentQuestion].CorrectAnswer.ToString().ToLower(); // Convert to lower case for comparison

        if (userAnswer == correctAnswer)
        {
            Debug.Log("Correct Answer!");
            Correct();
        }
        else
        {
            Incorrect();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the score display
    }

    void ShowFinalScore()
    {
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + score; // Display the final score
        QuestionImage.gameObject.SetActive(false); // Optionally hide the question image
        inputField.gameObject.SetActive(false); // Optionally hide the input field
    }

}
