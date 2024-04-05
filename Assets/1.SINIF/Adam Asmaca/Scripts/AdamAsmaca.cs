using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using System.Security.Cryptography;

public class AdamAsmaca : MonoBehaviour
{
    public GameObject word;
    public GameObject sentance;
    public  GameObject optionA;
    public GameObject optionB;
    public GameObject optionC;
    public TextMeshProUGUI text;
    public TextMeshProUGUI optionAText;
    public TextMeshProUGUI optionBText;
    public TextMeshProUGUI optionCText;
    public int correctNum;
    public static int can=5;
    public bool[] taken;


    //public int numWords;
    //public int numSentences;
    public String[] words;
    public String[] sentences;
    public String[] hintWords;
    public String[] hintSentences;

    // Start is called before the first frame update
    void Awake(){
        options(1);
        text.text="";   
    }


    public void sentenceQ(){
        word.SetActive(false);
        sentance.SetActive(false);
        options(0);
        Debug.Log("Sentence");
    }
    public void wordQ(){
        word.SetActive(false);
        sentance.SetActive(false);
        options(0);
        Debug.Log("Word");
        int qNum=Random.Range(0,words.Length);
        text.text=hintWords[qNum];
        taken[qNum]=true;
    }
    void hangMan(){

    }
    void checkAnswer(){
        
    }
    void options(int a){
        if(a==0){
        optionA.SetActive(true);
        optionB.SetActive(true);
        optionC.SetActive(true);
        }
        else{
        optionA.SetActive(false);
        optionB.SetActive(false);
        optionC.SetActive(false);
        }
    }
    void OptionModifier(int correctIndex){
        
    }
}

