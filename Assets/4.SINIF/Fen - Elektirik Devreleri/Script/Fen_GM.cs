using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fen_GM : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI correctText; // TextMeshPro bileşenine referans
    private int correctMatches = 0;
    private int totalMatches;
    private ObjectMatchingGame[] matchingGames;

    private void Start()
    {
        matchingGames = FindObjectsOfType<ObjectMatchingGame>();
        totalMatches = matchingGames.Length;

        // Başlangıçta Text bileşenini gizle
        if (correctText != null)
        {
            correctText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Correct Text is not assigned!");
        }
    }

    public void OnCorrectMatch()
    {
        correctMatches++;
        Debug.Log($"Correct Matches: {correctMatches} / {totalMatches}");
        if (correctMatches == totalMatches)
        {
            ShowCorrectMessage();
        }
    }

    private void ShowCorrectMessage()
    {
        if (correctText != null)
        {
            correctText.gameObject.SetActive(true);
            correctText.text = "Correct!";
            Debug.Log("All matches are correct! Showing correct message.");
        }
        else
        {
            Debug.LogError("Correct Text is not assigned!");
        }
    }

    private void Update()
    {
        if (correctMatches == totalMatches)
        {
            ShowCorrectMessage();
        }
    }
}
