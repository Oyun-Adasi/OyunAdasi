using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoGamePlay : MonoBehaviour
{
    public VideoPlayerScript videoPlayerScript;
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
    bool[] takenAns;
    bool[] askedIndexes;
    int correctIndex;
    int score=100;
    CustomGameObject clickedOption;
    public int numberOfQuestions;
    public GameObject resetButton;
    public Button videoButton;
    void Awake()
    {
        resetButton.SetActive(false);
        videoPlayerScript=FindFirstObjectByType<VideoPlayerScript>();
        //Debug.Log(videoPlayerScript.videoUrls.Count);
        numberOfQuestions=videoPlayerScript.videoUrls.Count;
        takenAns = new bool[videoPlayerScript.videoUrls.Count];
        askedIndexes = new bool[videoPlayerScript.videoUrls.Count];
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
        playGame();
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
            videoPlayerScript.index=index;
            return index;
        }
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
    public void OptionSelectedA()
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
    void CheckAnswer()
{
    if (answers[correctIndex] == clickedOption.optionText.text)
    {
        //Debug.Log("Correct");
        playGame();
    }
    else
    {
        //Debug.Log("Wrong");
        clickedOption.gameObject.SetActive(false);
        q.text="Yanlış! "+questions[correctIndex];
        score-=score/numberOfQuestions;
    }
    
}
public void playGame()
    {
        options(0);
        correctIndex = CorrectAnswerDecider(askedIndexes);
        Debug.Log(correctIndex);
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
            videoPlayerScript.index=correctIndex;
            q.text = questions[correctIndex];
            takenAns[correctIndex] = true;
            OptionModifier(correctIndex, answers);
            askedIndexes[correctIndex] = true;
        }
    }
    void GameOver(){
        q.text="Oyunu bitirdiniz! Tebrikler! Puanınınız: "+score;
        options(1);
        resetButton.SetActive(true);
        videoButton.interactable=false;

    }
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}