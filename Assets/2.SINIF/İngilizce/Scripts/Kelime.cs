using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Kelime : MonoBehaviour
{
    new Collider2D collider2D;
    public TextMeshProUGUI word;
    public GameObject doğruText;
    public GameObject yanlışText;
    public TextMeshProUGUI bitirme;
    public string[] kelimeler;
    int remainingIndex0;
    int remainingIndex1;
    int score=100;
    int neededItems=1;
    int putItems=0;
    public TextMeshProUGUI start;

void Awake()
{
    doğruText.SetActive(false);
    yanlışText.SetActive(false);
    collider2D = GetComponent<Collider2D>();
}
void Start()
{
    word.text=randomWord();
}


   
public void CheckDroppedObject(GameObject droppedObject)
{
    string droppedObjectName = droppedObject.name;
    bool found = false;

    for (int i = 0; i < kelimeler.Length; i++)
    {
        if (kelimeler[i] == droppedObjectName)
        {
            yanlışText.SetActive(false);
            doğruText.SetActive(true);
            found = true;
            droppedObject.SetActive(false);
            putItems++;
            break;
            
        }
        else 
        {
            doğruText.SetActive(false);
            yanlışText.SetActive(true);
        }
    }

    if (!found)
    {
        Debug.Log("Yanlış!");
        yanlışText.SetActive(true);
        doğruText.SetActive(false);
        score-=10;
        putItems++;
    }
}
    public string randomWord(){
        int randomIndex = Random.Range(0, kelimeler.Length);
        return kelimeler[randomIndex];
    }

    public void Finish(){
        doğruText.SetActive(false);
        yanlışText.SetActive(false);
        if(score==100&&putItems==neededItems){
            bitirme.text="Tebrikler! Tüm gerekli eşyaları koydun!";
        }
        else{
            bitirme.text="Maalesef tüm eşyaları koyamadın. Tekrar dene!";
        }
    }
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

