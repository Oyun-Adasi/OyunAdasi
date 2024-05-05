using System.Collections;
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class QtsManager : MonoBehaviour
{
  public Text questionText;
  public Text scoreText;
  public Text FinalScore;
  public Button[] answButtons;
  public QuestionData qtsDatas;
  public GameObject True;
  public GameObject Wrong;
  public GameObject GameOver;
  public GameObject Resets;

  private int currentQts = 0;
  private static float scr = 100;
  private static int scrYanlis = 0;
  public int wrongRply = 0;

  void Start()
  {
    SetQuestion(currentQts);
    True.gameObject.SetActive(false);
    Wrong.gameObject.SetActive(false);
    GameOver.gameObject.SetActive(false);
    Resets.gameObject.SetActive(false);
  }

  void SetQuestion(int questionIndex)
  {
    if (qtsDatas != null && qtsDatas.questions != null && questionIndex < qtsDatas.questions.Length) // Check for null references before accessing data
    {
      questionText.text = qtsDatas.questions[questionIndex].questionText;

      foreach (Button r in answButtons)
      {
        r.onClick.RemoveAllListeners();
      }

      for (int i = 0; i < answButtons.Length; i++)
      {
        
        if (answButtons[i].GetComponentInChildren<Text>() != null)
        {
          answButtons[i].GetComponentInChildren<Text>().text = qtsDatas.questions[questionIndex].replies[i];
        }
        
        int replyIndex = i;
        answButtons[i].onClick.AddListener(() => { CheckReply(replyIndex); });
      }
    }
    else
    {
      
      Debug.LogError("qtsData or questions array is null!");
    }
  }

  void CheckReply(int replyIndex)
  {
    if (replyIndex == qtsDatas.questions[currentQts].correctReplyIndex)
    {
      True.gameObject.SetActive(true);

      foreach (Button r in answButtons)
      {
        r.interactable = false;
      }

      StartCoroutine(Next());
    }
    else
    {
      wrongRply = replyIndex;
      scrYanlis++;
      scr = scr - scr / 6;
      scoreText.text = "" + scr;
      Wrong.gameObject.SetActive(true);
      
      StartCoroutine(NextFalse());
    }
  }

  IEnumerator Next()
  {
    yield return new WaitForSeconds(2);

    currentQts++;

    if (currentQts < qtsDatas.questions.Length)
    {
      Reset();
    }
    else
    {
      GameOver.SetActive(true);
      Resets.gameObject.SetActive(true);

      FinalScore.text = "Puanınız: " + scr + "\nYanlış Sayınız: " + scrYanlis;

      if (scrYanlis > 0)
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
    
    answButtons[wrongRply].interactable = false;
  }

  public void Reset()
  {
    True.SetActive(false);
    Wrong.SetActive(false);

    foreach (Button r in answButtons)
    {
      r.interactable = true;
    }

    SetQuestion(currentQts);
  }

  public void Restart()
  {
    currentQts = 0;
    scr = 100;
    scrYanlis = 0;
    
    SetQuestion(currentQts);
    True.gameObject.SetActive(false);
    Wrong.gameObject.SetActive(false);
    GameOver.gameObject.SetActive(false);
    Resets.gameObject.SetActive(false);
    
    foreach (Button r in answButtons)
    {
      r.interactable = true;
    }
  }
}
