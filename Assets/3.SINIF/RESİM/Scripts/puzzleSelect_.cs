using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class puzzleSelect_ : MonoBehaviour
{
   public GameObject StartPanel;
   public void SetPuzzlesPhoto(Image Photo){
    StartPanel.SetActive(true);
    for(int i = 0;i<16;i++){
        GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
    }
    StartPanel.SetActive(false);
   }
}
