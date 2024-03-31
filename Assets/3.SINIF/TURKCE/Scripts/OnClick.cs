using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnClick : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void PlayVoice()
    {
        audioSource.Play();
    }
}
