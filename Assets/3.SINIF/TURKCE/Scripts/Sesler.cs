using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sesler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Play();
    }
}
