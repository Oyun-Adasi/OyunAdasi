using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;
public class Game : MonoBehaviour
{
    public Text anlikHizText;
    private string answertag;
    public Image levhapanel;
    [SerializeField] private List<Sprite> levhalar;
    private string dogruButton;
    private int score;
    public int anlikHiz;
    void Start()
    {
        anlikHiz = int.Parse(anlikHizText.text);
        int randomIndex = Random.Range(0, 6);
        levhapanel.sprite = levhalar[randomIndex];

        if (randomIndex == 0)
        {
            dogruButton = "fren";
        }
        else if (randomIndex == 1)
        {
            dogruButton = "sol";
        }
        else if (randomIndex == 2)
        {
            dogruButton = "sag";
        }
        else if (randomIndex == 3)
        {
            if (anlikHiz <= 30)
            {
                dogruButton = "gaz";
                anlikHiz = 30;
            }
            else
            {
                dogruButton = "fren";
                anlikHiz = 30;
            }
        }
        else if (randomIndex == 4)
        {
            if (anlikHiz <= 40)
            {
                dogruButton = "gaz";
                anlikHiz = 40;
            }
            else
            {
                dogruButton = "fren";
                anlikHiz = 40;
            }
        }
        else if (randomIndex == 5)
        {
            if (anlikHiz <= 50)
            {
                dogruButton = "gaz";
                anlikHiz = 50;
            }
            else
            {
                dogruButton = "fren";
                anlikHiz = 50;
            }
        }
    }
    
    void Update()
    {
        
    }

    public void onClickButton()
    {
        answertag = EventSystem.current.currentSelectedGameObject.tag;
        if (dogruButton == answertag)
        {
            anlikHizText.text = anlikHiz.ToString();
            score++;
            Debug.Log("Tebrikler! Doğru cevap.");
            Start();
        }
        else
        {
            score--;
            Debug.Log("Yanlış Cevap.");
            Start();
        }
    }
}
