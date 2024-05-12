using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
public class piecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(3.3f,8.5f),Random.Range(4f,-3.8f),0);
    }

        void Update()
    {
        
        if(Vector3.Distance(transform.position,RightPosition) <0.5f){
            if(!Selected){
                if(InRightPosition == false){
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;

                }
                
            }
        }
    }
}
