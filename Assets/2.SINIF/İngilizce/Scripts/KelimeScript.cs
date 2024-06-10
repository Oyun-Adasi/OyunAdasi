using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KelimeScript : MonoBehaviour
{

    public TextMeshProUGUI word;
    public GameObject doğruText;
    public GameObject yanlışText;
    public TextMeshProUGUI bitirme;
    public Kelime[] kelimeler;
    int score=100;
    int putItems=0;
    int randomIndex;
    public GameObject dropZone;
    private int numOfObjects; 

void Awake()
{
    doğruText.SetActive(false);
    yanlışText.SetActive(false);
    kelimeler=new Kelime[]{
        new Kelime(false,"Scissors"), new Kelime(false,"Measuring Triangle"),new Kelime(false,"Eraser"),new Kelime(false, "Protractor")
    };
    numOfObjects=dropZone.transform.childCount;
}
void Start()
{
    word.text=randomWord();
}


public bool CheckDroppedObject(GameObject droppedObject)
{
    string droppedObjectName = droppedObject.name;

    if (kelimeler[randomIndex].kelime == droppedObjectName)
    {
        yanlışText.SetActive(false);
        doğruText.SetActive(true);

        putItems++;
        word.text = randomWord();
        return true;
    }
    else
    {
        doğruText.SetActive(false);
        yanlışText.SetActive(true);
        score -= score/numOfObjects;
        putItems++;
        Debug.Log("Yanlış");
        return false;
    }
}    public string randomWord()
{
    int remainingWords = 0;
    foreach (Kelime kelime in kelimeler)
    {
        if (!kelime.taken)
        {
            remainingWords++;
        }
    }

    if (remainingWords == 0)
    {

        foreach (Kelime kelime in kelimeler)
        {
            kelime.taken = false;
        }

    }

    do
    {
        randomIndex = Random.Range(0, kelimeler.Length);
    } while (kelimeler[randomIndex].taken);

    kelimeler[randomIndex].taken = true;
    return kelimeler[randomIndex].kelime;
}

public void Finish()
{
    doğruText.SetActive(false);
    yanlışText.SetActive(false);
    if (score == 100)
    {
        bitirme.text = "Well done! You answered all the questions correctly. Your score is: "+score;
    }
    else
    {
        bitirme.text = "Game is finished! Your score is: "+score;
    }
}
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
public class Kelime{
    public bool taken;
    public string kelime;
    public Kelime(bool taken, string kelime){
        this.taken=taken;
        this.kelime=kelime;
    }
}


