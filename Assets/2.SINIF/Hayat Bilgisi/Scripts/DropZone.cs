using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform dropZoneTransform;
    public GameObject droppedObject;
    public HBDrag HBDragScript;
    public int maxLives = 3;
    private int currentLives;
    public Text livesText;
    public SceneManagement sceneManagementScript;
    public GameObject dropZones;
    public int totalTries=0;


    private void Start()
    {
        currentLives = maxLives;
        UpdateLivesText();
        sceneManagementScript = FindAnyObjectByType<SceneManagement>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        
        Debug.Log(gameObject.name);
        HBDragScript = eventData.pointerDrag.GetComponent<HBDrag>();

        if (CheckDroppedObject(HBDragScript.gameObject.name, gameObject))
        {
            Debug.Log("OnDrop");
            HBDragScript.gameObject.SetActive(false);
            sceneManagementScript.totalTries++;
        }
        else
        {
            LoseLife();
            sceneManagementScript.score-=sceneManagementScript.score/sceneManagementScript.numOfObjects;
        }

        if (currentLives < 0)
        {
            sceneManagementScript.GameOver();
        }
    }

    public bool CheckDroppedObject(string droppedObject, GameObject dropZone)
    {
        if (droppedObject == dropZone.name)
        {
            return true;
        }
        return false;
    }

    private void LoseLife()
    {
        currentLives--;
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        livesText.text = "Can: " + currentLives.ToString();
    }
}

