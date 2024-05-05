using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Buttons;
    public Button[] answers;
    public GameObject[] gameObjects;
    private string answertag;
    private GameObject activeObject;
    private int score;
    private int mistakecount;
    public GameObject True;
    public GameObject False;
    public GameObject gameover;
    public Text FScore;
    void Start()
    {
        Panel.SetActive(false);
        Buttons.SetActive(false);
        True.SetActive(false);
        False.SetActive(false);
        gameover.SetActive(false);

        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }

        // Set a random gameObject (video) to active
        int randomIndex = Random.Range(0, gameObjects.Length);
        activeObject = gameObjects[randomIndex];
        activeObject.SetActive(true);

        StartCoroutine(DeactivateAfterDelay());
    }

    private void Update()
    {
       GameOver();
    }

    private IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(10f);

        activeObject.SetActive(false);

        // Activate Panel and Buttons
        Panel.SetActive(true);
        Buttons.SetActive(true);
    }
   private IEnumerator NextQ(){
       yield return new WaitForSeconds(3f);
       Start();
   }
   public void OnClick()
    {
        answertag = EventSystem.current.currentSelectedGameObject.tag;
        Debug.Log(answertag);
        if (activeObject.tag == answertag)
        {
            score++;
            Debug.Log(score);
            True.SetActive(true);
            StartCoroutine(NextQ());
            
        }
        else
        {
            mistakecount++;
            Debug.Log(score);
            False.SetActive(true);
            StartCoroutine(NextQ());
        }
        
    }

    void GameOver()
    {
        if (mistakecount >= 2)
        {
            gameover.SetActive(true); 
            Panel.SetActive(false);
            Buttons.SetActive(false);
            True.SetActive(false);
            False.SetActive(false);
            activeObject.SetActive(false);
            FScore.text = "Skorunuz:"+score;
        }
    }

    public void Reset()
    {
        score = 0;
        mistakecount = 0;
        Start();
    }

   
}