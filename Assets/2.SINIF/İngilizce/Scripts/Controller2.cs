using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class classObject2
{
    public Image image;
    public GameObject movedObject;
    public string ders;
}

public class Controller2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Transform parentAfterDrag;
    private Image image;
    private KelimeScript dersProgScript;
    private Vector2 initialPosition;
    bool isInPlace=false;
    [SerializeField] Transform dropZone;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        initialPosition = rectTransform.anchoredPosition;


        // Find the DersProg script in the scene
        dersProgScript = FindObjectOfType<KelimeScript>();
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
        isInPlace = false; // Reset isInPlace flag when dragging the object
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drop();
        if (isInPlace)
        {
            if (dersProgScript != null)
            {
                bool guessCorrect = dersProgScript.CheckDroppedObject(gameObject);
                if (guessCorrect)
                {
                    transform.SetParent(dropZone);
                }
            }
            else
            {
                Debug.LogError("DersProg script not found.");
            }
        }
    }

    void Drop()
    {
        if (rectTransform.anchoredPosition.x >= -100 && rectTransform.anchoredPosition.x <= 100 &&
            rectTransform.anchoredPosition.y >= -100 && rectTransform.anchoredPosition.y <= 100)
        {
            rectTransform.anchoredPosition = Vector2.zero;
            isInPlace = true; // Set isInPlace flag when object is within the drop zone
        }
        else
        {
            isInPlace = false; // Reset isInPlace flag when object is outside the drop zone
        }
    }
}