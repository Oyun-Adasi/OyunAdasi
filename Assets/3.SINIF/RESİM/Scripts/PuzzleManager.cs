using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public piecesScript[] puzzlePieces;
    public GameObject messageText; // Mesajı gösterecek UI Text
    public Button resetButton; // Reset tuşu
    public Button changePuzzleButton; // Puzzle Değiştir tuşu
    public Text scoreText; // Skor gösterecek UI Text
    public GameObject startPanel; // Başlangıç paneli

    private int score;
    private float elapsedTime;

    void Start()
    {
        // Tüm parçaları bul ve diziye ata
        puzzlePieces = FindObjectsOfType<piecesScript>();

        // Reset butonuna tıklama olayını ata
        resetButton.onClick.AddListener(ResetPuzzle);

        // Puzzle değiştir butonuna tıklama olayını ata
        changePuzzleButton.onClick.AddListener(ChangePuzzle);

        // Mesaj ve butonları başlangıçta gizle
        messageText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        changePuzzleButton.gameObject.SetActive(false);

        // Skoru başlangıç değeri olan 1000'e ayarla
        score = 1000;
        elapsedTime = 0;
        UpdateScoreText();
    }

    void Update()
    {
        // Zamanı takip et ve skoru güncelle
        elapsedTime += Time.deltaTime;
        score = 1000 - (int)(elapsedTime * 10);
        UpdateScoreText();

        // Tüm parçaların doğru pozisyonda olup olmadığını kontrol et
        bool allInRightPosition = true;

        foreach (piecesScript piece in puzzlePieces)
        {
            if (!piece.InRightPosition)
            {
                allInRightPosition = false;
                break;
            }
        }

        // Eğer tüm parçalar doğru pozisyondaysa, mesajı ve butonları göster
        if (allInRightPosition)
        {
            messageText.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            changePuzzleButton.gameObject.SetActive(true);
            enabled = false; // Kontrolü durdurmak için script'i devre dışı bırak
        }
    }

    // Puzzle'ı resetlemek için kullanılacak fonksiyon
    void ResetPuzzle()
    {
        foreach (piecesScript piece in puzzlePieces)
        {
            piece.ResetPosition();
        }

        // Skoru ve zamanı resetle
        score = 1000;
        elapsedTime = 0;
        UpdateScoreText();

        // Mesaj ve butonları tekrar gizle
        messageText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        changePuzzleButton.gameObject.SetActive(false);

        // Script'i tekrar aktif et
        enabled = true;
    }

    // Puzzle değiştir butonu için kullanılacak fonksiyon
    void ChangePuzzle()
    {
        foreach (piecesScript piece in puzzlePieces)
        {
            piece.ResetPosition();
        }

        // Skoru ve zamanı resetle
        score = 1000;
        elapsedTime = 0;
        UpdateScoreText();

        // Başlangıç panelini göster
        startPanel.SetActive(true);

        // Mesaj ve butonları gizle
        messageText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        changePuzzleButton.gameObject.SetActive(false);
        ResetPuzzle();
    }

    // Skor metnini güncelle
    void UpdateScoreText()
    {
        scoreText.text = "Skor: " + score.ToString();
    }
}

