using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;
public class Game : MonoBehaviour
{
    private string answertag;
    public Button[] buttonlar;
    public SpriteRenderer levhapanel;
    [SerializeField] private List<Sprite> levhalar;
    private string dogruButton;
    private int score;
    void Start()
    {
        int randomIndex = Random.Range(0, 3);
        levhapanel.sprite = levhalar[randomIndex];

        if (randomIndex == 0)
        {
            dogruButton = "fren";
        }
        else if (randomIndex == 1)
        {
            dogruButton = "sol";
        }
        else
        {
            dogruButton = "sag";
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
