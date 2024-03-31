using System.Collections;
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
  public Text questionText;
  public Text scoreText;
  public Text FinalScore;
  public Button[] replyButtons;
  public QtsData qtsData;
  public GameObject Right;
  public GameObject Wrong;
  public GameObject GameFinished;
  public GameObject Reset1;

  private int currentQuestion = 0;
  private static float score = 100;
  private static int scoreYanlis = 0;
  public int wrongReply = 0;

  void Start()
  {
    SetQuestion(currentQuestion);
    Right.gameObject.SetActive(false);
    Wrong.gameObject.SetActive(false);
    GameFinished.gameObject.SetActive(false);
    Reset1.gameObject.SetActive(false);
  }

  void SetQuestion(int questionIndex)
  {
    if (qtsData != null && qtsData.questions != null && questionIndex < qtsData.questions.Length) // Check for null references before accessing data
    {
      questionText.text = qtsData.questions[questionIndex].questionText;

      foreach (Button r in replyButtons)
      {
        r.onClick.RemoveAllListeners();
      }

      for (int i = 0; i < replyButtons.Length; i++)
      {
        
        if (replyButtons[i].GetComponentInChildren<Text>() != null)
        {
          replyButtons[i].GetComponentInChildren<Text>().text = qtsData.questions[questionIndex].replies[i];
        }
        
        int replyIndex = i;
        replyButtons[i].onClick.AddListener(() => { CheckReply(replyIndex); });
      }
    }
    else
    {
      
      Debug.LogError("qtsData or questions array is null!");
    }
  }

  void CheckReply(int replyIndex)
  {
    if (replyIndex == qtsData.questions[currentQuestion].correctReplyIndex)
    {
      Right.gameObject.SetActive(true);

      foreach (Button r in replyButtons)
      {
        r.interactable = false;
      }

      StartCoroutine(Next());
    }
    else
    {
      wrongReply = replyIndex;
      scoreYanlis++;
      score = score - score / 6;
      scoreText.text = "" + score;
      Wrong.gameObject.SetActive(true);
      
      StartCoroutine(NextFalse());
    }
  }

  IEnumerator Next()
  {
    yield return new WaitForSeconds(2);

    currentQuestion++;

    if (currentQuestion < qtsData.questions.Length)
    {
      Reset();
    }
    else
    {
      GameFinished.SetActive(true);
      Reset1.gameObject.SetActive(true);

      FinalScore.text = "Puanınız: " + score + "\nYanlış Sayınız: " + scoreYanlis;

      if (scoreYanlis > 0)
      {
        FinalScore.text += "\nDaha iyisini yapabilirsin";
      }
      else
      {
        FinalScore.text += "\nTebrikler!";
      }
    }
  }

  IEnumerator NextFalse()
  {
    yield return new WaitForSeconds(2);

    Wrong.gameObject.SetActive(false);
    
    replyButtons[wrongReply].interactable = false;
  }

  public void Reset()
  {
    Right.SetActive(false);
    Wrong.SetActive(false);

    foreach (Button r in replyButtons)
    {
      r.interactable = true;
    }

    SetQuestion(currentQuestion);
  }

  public void Restart()
  {
    currentQuestion = 0;
    score = 100;
    scoreYanlis = 0;
    
    SetQuestion(currentQuestion);
    Right.gameObject.SetActive(false);
    Wrong.gameObject.SetActive(false);
    GameFinished.gameObject.SetActive(false);
    Reset1.gameObject.SetActive(false);
    
    foreach (Button r in replyButtons)
    {
      r.interactable = true;
    }
  }
}