using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CityUIManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] optionButtons;
    private City currentIl;

    public void DisplayQuestion(string question, string[] options, City il)
    {
        currentIl = il;
        questionText.text = question;
        for (int i = 0; i < options.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];
            string selectedOption = options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(selectedOption));
        }
    }

    void OnOptionSelected(string selectedOption)
    {
        bool isCorrect = selectedOption == currentIl.ilAdi;
        Debug.Log("Seçilen cevap: " + selectedOption + ", Doğru: " + isCorrect);

        currentIl.SetAnswerResult(isCorrect);

        // Seçenekleri devre dışı bırak
        foreach (var button in optionButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
