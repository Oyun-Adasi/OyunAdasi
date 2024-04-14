using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{
    public Text questionText;
    public Button noseButton;
    public Button earButton;
    public Button earButton2;
    public Button eyeButton;
    public Button eyeButton2;

    public Button choiceButton1;
    public Button choiceButton2;
    public Button choiceButton3;

    private Button correctButton;
    private Button correctButton2;
    private bool isSecondPartActive = false;

    private string[] problemTexts = { "Merhaba Doktor, gözlerim biraz bulanık görüyor.", "Merhaba Doktor, etrafımdaki şeylerin kokusunu alamıyorum.", "Merhaba Doktor, etrafımdaki sesleri çok kısık duyuyorum." };

    private void Start()
    {
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        choiceButton3.gameObject.SetActive(false);
        string problem = problemTexts[Random.Range(0, problemTexts.Length)];
        questionText.text = problem;

        
        if (problem == problemTexts[0])
        {
            correctButton = eyeButton;
            correctButton2 = eyeButton2;
        }
        else if (problem == problemTexts[1])
        {
            correctButton = noseButton;
        }
        else if (problem == problemTexts[2])
        {
            correctButton = earButton;
            correctButton2 = earButton2;
        }
    }
    
    public void SelectButton(Button selectedButton)
    {
        if (!isSecondPartActive)
        {
            if (selectedButton == correctButton || selectedButton == correctButton2)
            {
                Debug.Log("Correct! Activate the choice buttons.");
                
                choiceButton1.gameObject.SetActive(true);
                choiceButton2.gameObject.SetActive(true);
                choiceButton3.gameObject.SetActive(true);
                isSecondPartActive = true;
            }
            else
            {
                Debug.Log("Wrong pick. Try again.");
            }
        }
    }

    public void TreatEye()
    {
        if (correctButton == eyeButton || correctButton == eyeButton2)
        {
            Debug.Log("Correct! Give the patient a glass to wear.");
        }
        else
        {
            Debug.Log("Try again.");
        }
    }

    public void TreatNose()
    {
        if (correctButton == noseButton)
        {
            Debug.Log("Correct! Give the patient a nose spray.");
        }
        else
        {
            Debug.Log("Try again.");
        }
    }

    public void TreatEar()
    {
        if (correctButton == earButton || correctButton == earButton2)
        {
            Debug.Log("Correct! Give the patient a hearing aid.");
        }
        else
        {
            Debug.Log("Try again.");
        }
    }
}