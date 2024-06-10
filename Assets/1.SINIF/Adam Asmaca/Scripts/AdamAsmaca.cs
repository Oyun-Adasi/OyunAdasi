using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using System.Data;
using UnityEngine.SceneManagement;
public class CustomGameObject
{
    public GameObject gameObject;
    public TextMeshProUGUI optionText;
    public bool taken;
    public Button button;
    public string qType;
}
public class AdamAsmaca : MonoBehaviour
{
    public GameObject can10;
    public GameObject can9;
    public GameObject can8;
    public GameObject can7;
    public GameObject can6;
    public GameObject can5;
    public GameObject can4;
    public GameObject can3;
    public GameObject can2;
    public GameObject can1;
    public GameObject can0;

    public GameObject word;
    public GameObject sentence;
    public GameObject devamEt;
    public GameObject optiona;
    public GameObject optionb;
    public GameObject optionc;
    public GameObject Restart;
    public CustomGameObject optionA;
    public CustomGameObject optionB;
    public CustomGameObject optionC;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public TextMeshProUGUI text;
    public TextMeshProUGUI canText;
    int score=100;
    public static int can=10;
    bool[] takenWords;
    bool[] takenSentences;
    public String[] words;
    public String[] sentences;
    public String[] hintWords;
    public String[] hintSentences;
    public CustomGameObject[] optionArr;
    int correctIndex;
    bool[] askedIndexesWord;
    bool[] askedIndexesSentences;
    void Start()
    {
        
        Restart.SetActive(false);
        devamEt.SetActive(false);
        can9.SetActive(false);
        can8.SetActive(false);
        can7.SetActive(false);
        can6.SetActive(false);
        can5.SetActive(false);
        can4.SetActive(false);
        can3.SetActive(false);
        can2.SetActive(false);
        can1.SetActive(false);
        can0.SetActive(false);
        optionA = new CustomGameObject();
        optionA.gameObject = optiona;
        optionA.optionText = optiona.GetComponentInChildren<TextMeshProUGUI>();
        optionA.button=buttonA;
        optionB = new CustomGameObject();
        optionB.gameObject = optionb;
        optionB.optionText = optionb.GetComponentInChildren<TextMeshProUGUI>();
        optionB.button=buttonB;
        optionC = new CustomGameObject();
        optionC.gameObject = optionc;
        optionC.optionText = optionc.GetComponentInChildren<TextMeshProUGUI>();
        optionC.button=buttonC;
        optionArr=new CustomGameObject[3];
        optionArr[0]=optionA;
        optionArr[1]=optionB;
        optionArr[2]=optionC;

        options(1);
        RegisterButtonClickListeners();
        askedIndexesWord=new bool[words.Length];
        askedIndexesSentences=new bool[sentences.Length];
        takenWords=new bool[words.Length];
        takenSentences=new bool[sentences.Length];
    }
    void Update(){
        canCheck();
    }
    public void sentenceQ(){
        qTypeSetter(0);
        options(0);
        devamEt.SetActive(false);
        word.SetActive(false);
        sentence.SetActive(false);
        correctIndex=CorrectAnswerDecider(askedIndexesSentences);
        if(correctIndex==-1||can<0){
            GameOver();
        }
        else{
            while(askedIndexesSentences[correctIndex]){
                correctIndex=Random.Range(0,sentences.Length);
            }
            text.text=sentences[correctIndex];
            takenSentences[correctIndex]=true;
            OptionModifier(correctIndex, hintSentences);
            askedIndexesSentences[correctIndex]=true;
        }
    }
    public void wordQ(){
        qTypeSetter(1);
        options(0);
        devamEt.SetActive(false);
        word.SetActive(false);
        sentence.SetActive(false);
        correctIndex=CorrectAnswerDecider(askedIndexesWord);
        if(correctIndex==-1||can<0){
            GameOver();
        }
        else{
            while(askedIndexesWord[correctIndex]){
                correctIndex=Random.Range(0,words.Length);
            }
            text.text=hintWords[correctIndex];
            takenWords[correctIndex]=true;
            OptionModifier(correctIndex, words);
            askedIndexesWord[correctIndex]=true;
        }
    }
    void options(int a){
        if(a==0){
        optionA.gameObject.SetActive(true);
        optionB.gameObject.SetActive(true);
        optionC.gameObject.SetActive(true);
        }
        else{
        optionA.gameObject.SetActive(false);
        optionB.gameObject.SetActive(false);
        optionC.gameObject.SetActive(false);
        }
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
    void RegisterButtonClickListeners()
    {
        optionA.button.onClick.AddListener(() => OnAnswerClick(optionA));
        optionB.button.onClick.AddListener(() => OnAnswerClick(optionB));
        optionC.button.onClick.AddListener(() => OnAnswerClick(optionC));
    }

    void OnAnswerClick(CustomGameObject option)
{
    string[] arr;
    string[] arr2;
    if (optionA.qType == "sentence")
    {
        arr = hintSentences;
        arr2=sentences;
    }
    else
    {
        arr = words;
        arr2=hintWords;
    }

    Debug.Log("Option clicked: " + option.optionText.text);
    if (option.optionText.text == arr[correctIndex])
    {
        text.text = "Doğru!";
        options(1);
        resetTakenArr();
        resetOptions();
        devamEt.SetActive(true);
    }
    else
    {
        option.gameObject.SetActive(false);
        can--;
        BackgroundChanger(can);
        score=score-10;
        canText.text = "Can: " + can;
        if (can < 0)
        {
            GameOver();
        }
        else
        {
            text.text = "Yanlış! Tekrar dene! " + can + " canın kaldı! "+arr2[correctIndex];
        }
    }
}
    void resetTakenArr(){
        for(int i=0;i<3;i++){
            takenWords[i]=false;
            takenSentences[i]=false;
        }
    }
    void resetOptions(){
        optionA.taken=false;
        optionB.taken=false;
        optionC.taken=false;
        
    }
    int CorrectAnswerDecider(bool[] arr){
        int numAsked=0;
        int index;
        for(int i=0;i<arr.Length;i++){
            if(arr[i])
                numAsked++;
        }
        if(numAsked==arr.Length||can==0){
            options(1);
            devamEt.SetActive(false);
            Restart.SetActive(true);
            return -1;
        }
        else{
            index=Random.Range(0,arr.Length);
            while(arr[index]){
                index=Random.Range(0,arr.Length);
            }
        return index;
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        can=10;
    }
    void GameOver(){
        if(can==0){
            text.text="Oyun Bitti. Adam asıldı.";
            canText.text="";
        }
        else{
            text.text="Oyunu tamamen bitirdin. Tebrikler!"+" Puanın: "+score;
        }
        Restart.SetActive(true);
        options(1);
                
    }
    void qTypeSetter(int a){
        if(a==0){
            optionA.qType="sentence";
            optionB.qType="sentence";
            optionC.qType="sentence";
        }
        else{
            optionA.qType="word";
            optionB.qType="word";
            optionC.qType="word";
        }
    }
    public void DevamEt(){
        if(optionA.qType=="sentence")
            sentenceQ();
        else    
            wordQ();
        
    }
    void canCheck(){
        if(can==0){
            GameOver();
        }
    }
    void BackgroundChanger(int can){
        switch(can){
            case 9:
                can9.SetActive(true);
                break;
            case 8:
                can8.SetActive(true);
                break;
            case 7:
                can7.SetActive(true);
                break;
            case 6:
                can6.SetActive(true);
                break;
            case 5:
                can5.SetActive(true);
                break;
            case 4:
                can4.SetActive(true);
                break;
            case 3:
                can3.SetActive(true);
                break;
            case 2:
                can2.SetActive(true);
                break;
            case 1:
                can1.SetActive(true);
                break;
            case 0:
                can0.SetActive(true);
                break;
                
        }
    }
}


