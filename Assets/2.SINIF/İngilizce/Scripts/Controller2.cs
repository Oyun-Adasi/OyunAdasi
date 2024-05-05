using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Controller2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Transform parentAfterDrag;
    private Image image;
    private Kelime dersProgScript;
    private Vector2 initialPosition;
    bool isInPlace=false;
    [SerializeField] Transform dropZone;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        initialPosition = rectTransform.anchoredPosition;


        // Find the DersProg script in the scene
        dersProgScript = FindObjectOfType<Kelime>();
        if (dersProgScript == null)
        {
            Debug.LogError("DersProg script not found in the scene.");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       //parentAfterDrag = transform.parent;
        //transform.SetParent(parentAfterDrag.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drop();
        if(isInPlace){

            if (dersProgScript != null)
            {
                dersProgScript.CheckDroppedObject(gameObject);
            }
            else
            {
                Debug.LogError("DersProg script not found.");
            }

            transform.SetParent(dropZone);
        }
    }

    void Drop()
    {
        if (rectTransform.anchoredPosition.x >= -100 && rectTransform.anchoredPosition.x <= 100 &&
            rectTransform.anchoredPosition.y >= -100 && rectTransform.anchoredPosition.y <= 100)
        {
            rectTransform.anchoredPosition = Vector2.zero;
            isInPlace=true;
        }
    }
}