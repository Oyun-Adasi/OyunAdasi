using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Vplay : MonoBehaviour
{
    [SerializeField] public AudioClip[] audioClips;
    public string[] questions;
    public string[] answers;
    //public GameObject Restart;
    public CustomGameObject[] optionArr;
    public CustomGameObject optionA;
    public CustomGameObject optionB;
    public CustomGameObject optionC;
    public GameObject optiona;
    public GameObject optionb;
    public GameObject optionc;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public TextMeshProUGUI q;
    public Button voiceButton;
    bool[] takenAns;
    bool[] askedIndexes;
    int correctIndex;

    void Start()
    {
        voiceButton.onClick.AddListener(PlayAudioAndShowQuestion);
        optionA = new CustomGameObject();
        optionA.gameObject = optiona;
        optionA.optionText = optiona.GetComponentInChildren<TextMeshProUGUI>();
        optionA.button = buttonA;
        optionB = new CustomGameObject();
        optionB.gameObject = optionb;
        optionB.optionText = optionb.GetComponentInChildren<TextMeshProUGUI>();
        optionB.button = buttonB;
        optionC = new CustomGameObject();
        optionC.gameObject = optionc;
        optionC.optionText = optionc.GetComponentInChildren<TextMeshProUGUI>();
        optionC.button = buttonC;
        optionArr = new CustomGameObject[3];
        optionArr[0] = optionA;
        optionArr[1] = optionB;
        optionArr[2] = optionC;
        takenAns = new bool[questions.Length];
        askedIndexes = new bool[questions.Length];
        playGame();
    }

    void Update()
    {

    }

    void OptionModifier(int correctIndex, string[] arr)
    {
        int a = Random.Range(0, optionArr.Length);
        switch (a)
        {
            case 0:
                optionA.optionText.text = arr[correctIndex];
                optionA.taken = true;
                break;
            case 1:
                optionB.optionText.text = arr[correctIndex];
                optionB.taken = true;
                break;
            case 2:
                optionC.optionText.text = arr[correctIndex];
                optionC.taken = true;
                break;
        }

        List<string> unusedAns = new List<string>(arr);
        unusedAns.RemoveAt(correctIndex);

        for (int i = 0; i < optionArr.Length; i++)
        {
            if (!optionArr[i].taken)
            {
                int randomIndex = Random.Range(0, unusedAns.Count);
                optionArr[i].optionText.text = unusedAns[randomIndex];
                unusedAns.RemoveAt(randomIndex);
                optionArr[i].taken = true;
            }
        }
    }

    void PlayAudioAndShowQuestion()
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        AudioSource.PlayClipAtPoint(audioClips[randomIndex], Vector3.zero);

        ShowQuestionAndAnswers(randomIndex);
    }

    void ShowQuestionAndAnswers(int audioIndex)
    {
        // Soruyu göster
        int questionIndex = CorrectAnswerDecider(askedIndexes);
        if (questionIndex == -1)
        {
            // Game Over handling
            return;
        }

        while (askedIndexes[questionIndex])
        {
            questionIndex = Random.Range(0, questions.Length);
        }

        // Audio dosyasını çal
        AudioSource.PlayClipAtPoint(audioClips[audioIndex], Vector3.zero);

        q.text = questions[questionIndex];
        takenAns[questionIndex] = true;
        OptionModifier(questionIndex, questions);
        askedIndexes[questionIndex] = true;
    }

    void CheckAnswer(int correctIndex)
    {
        if (optionA.button.interactable || optionB.button.interactable || optionC.button.interactable)
        {
            return;
        }

        if (correctIndex == 0 && optionA.button.interactable)
        {
            // Correct answer
            // Handle correct answer
            playGame();
        }
        else if (correctIndex == 1 && optionB.button.interactable)
        {
            // Correct answer
            // Handle correct answer
            playGame();
        }
        else if (correctIndex == 2 && optionC.button.interactable)
        {
            // Correct answer
            // Handle correct answer
            playGame();
        }
        else
        {
            // Incorrect answer
            // Show same question again
            ShowQuestionAndAnswers(correctIndex);
        }
    }

    public void OptionSelected(int optionIndex)
    {
        CheckAnswer(correctIndex);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void options(int a)
    {
        if (a == 0)
        {
            optionA.gameObject.SetActive(true);
            optionB.gameObject.SetActive(true);
            optionC.gameObject.SetActive(true);
        }
        else
        {
            optionA.gameObject.SetActive(false);
            optionB.gameObject.SetActive(false);
            optionC.gameObject.SetActive(false);
        }
    }

    void ResetAskedArr()
    {
        for (int i = 0; i < 3; i++)
        {
            askedIndexes[i] = false;
        }
    }

    public void playGame()
    {
        options(0);
        correctIndex = CorrectAnswerDecider(askedIndexes);
        if (correctIndex == -1)
        {
            //GameOver();
        }
        else
        {
            while (askedIndexes[correctIndex])
            {
                correctIndex = Random.Range(0, questions.Length);
            }
            q.text = questions[correctIndex];
            takenAns[correctIndex] = true;
            OptionModifier(correctIndex, questions);
            askedIndexes[correctIndex] = true;
        }
    }

    public void audioPlay(int correctIndex)
    {
        Debug.Log(correctIndex);
    }

    int CorrectAnswerDecider(bool[] arr)
    {
        int numAsked = 0;
        int index;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i])
                numAsked++;
        }
        if (numAsked == arr.Length)
        {
            options(1);
            //Restart.SetActive(true);
            return -1;
        }
        else
        {
            index = Random.Range(0, arr.Length);
            while (arr[index])
            {
                index = Random.Range(0, arr.Length);
            }
            return index;
        }
    }
}
