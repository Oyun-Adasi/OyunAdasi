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
    bool isQuestionDisplayed = false;
    CustomGameObject clickedOption;
    bool isCorrect;

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

    void OptionModifier(int correctIndex, string[] arr)
{
    List<string> options = new List<string>(arr);
    
    // Shuffle the options
    options = ShuffleList(options);
    
    // Assign the options to the buttons
    optionA.optionText.text = options[0];
    optionB.optionText.text = options[1];
    optionC.optionText.text = options[2];
    
    // Mark the options as taken
    optionA.taken = true;
    optionB.taken = true;
    optionC.taken = true;
}

List<string> ShuffleList(List<string> list)
{
    List<string> shuffledList = new List<string>(list);
    
    // Shuffle the list using Fisher-Yates shuffle algorithm
    for (int i = shuffledList.Count - 1; i > 0; i--)
    {
        int j = Random.Range(0, i + 1);
        string temp = shuffledList[i];
        shuffledList[i] = shuffledList[j];
        shuffledList[j] = temp;
    }
    
    return shuffledList;
}

void PlayAudioAndShowQuestion()
{
    AudioSource.PlayClipAtPoint(audioClips[correctIndex], Vector3.zero);
    isQuestionDisplayed = true;
}

    void ShowQuestionAndAnswers()
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
        AudioSource.PlayClipAtPoint(audioClips[questionIndex], Vector3.zero);

        q.text = questions[questionIndex];
        takenAns[questionIndex] = true;
        OptionModifier(questionIndex, questions);
        askedIndexes[questionIndex] = true;
    }

    void CheckAnswer()
{
    if (answers[correctIndex] == clickedOption.optionText.text)
    {
        Debug.Log("Correct");
        // Correct answer
        isCorrect = true;
        playGame();
    }
    else
    {
        // Wrong answer
        Debug.Log("Wrong");
        clickedOption.gameObject.SetActive(false);
        isCorrect = false;
    }
}    public void OptionSelectedA()
    {
        clickedOption=optionA;
        CheckAnswer();
    }
    public void OptionSelectedB()
    {
        clickedOption=optionB;
        CheckAnswer();
    }
    public void OptionSelectedC()
    {
        clickedOption=optionC;
        CheckAnswer();
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
            GameOver();
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
    void GameOver(){
        q.text="Oyunu bitirdiniz! Tebrikler!";
        options(1);
        voiceButton.interactable=false;
    }
}
