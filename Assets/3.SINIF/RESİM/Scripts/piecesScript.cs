using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class piecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    private Vector3 InitialPosition;
    public bool InRightPosition;
    public bool Selected;

    void Start()
    {
        RightPosition = transform.position;
        InitialPosition = new Vector3(Random.Range(3.3f,8.5f),Random.Range(4f,-3.8f),0);
        transform.position = InitialPosition;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position,RightPosition) < 0.5f)
        {
            if(!Selected)
            {
                if(InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }

    // Parçayı başlangıç konumuna döndüren fonksiyon
    public void ResetPosition()
    {
        transform.position = InitialPosition;
        InRightPosition = false;
        GetComponent<SortingGroup>().sortingOrder = 1; // Resetleme sırasında parçanın görünümünü sıfırlamak için
    }
}
