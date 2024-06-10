using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerT : MonoBehaviour
{
    public GameObject VoiceQ;
    public GameObject VideoQ;
    public GameObject MainCanvas;
    void Awake(){
        VoiceQ.SetActive(false);
        VideoQ.SetActive(false);
    }
    public void PlayVoiceQ(){
        VoiceQ.SetActive(true);
        MainCanvas.SetActive(false);
    }
        public void PlayVideoQ(){
        VideoQ.SetActive(true);
        MainCanvas.SetActive(false);
    }
}
