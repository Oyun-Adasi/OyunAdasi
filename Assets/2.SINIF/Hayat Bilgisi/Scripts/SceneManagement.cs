using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SceneManagement : MonoBehaviour
{
    public GameObject canvas;
    public GameObject gameOverCanvas;
    public GameObject dropZones;
    public int numOfObjects;
    public int totalTries=0;
    public TextMeshProUGUI gameOverText;
    public GameObject warning;
    public DropZone dropZoneScript;
    public int score=100;

    void Awake(){
        gameOverCanvas.SetActive(false);
        numOfObjects = dropZones.transform.childCount;
        Debug.Log(numOfObjects);
        warning.SetActive(false);
    }
    public void GameOver(){
        canvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void checkAnswers()
    {
        Debug.Log("Kontrol");
        Debug.Log(totalTries);
        Debug.Log(numOfObjects);
        if (totalTries == numOfObjects)
        {
            GameOver();
            if (score == 100)
            {
                gameOverText.text = "Tebrikler! Hepsini doğru bildin. Puanın: " + score;
            }
            else
            {
                gameOverText.text = "Oyunu tamamladın! Puanın: " + score;
            }
        }
        else
            {
                warning.SetActive(true);
            }
    }
}
