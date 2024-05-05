using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform dropZoneTransform;
    public GameObject droppedObject;
    public HBDrag HBDragScript;
    public int maxLives = 3;
    private int currentLives;

    public Text livesText;
    public GameObject gameOverText;

    private void Start()
    {
        currentLives = maxLives;
        UpdateLivesText();
        gameOverText.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        HBDragScript = eventData.pointerDrag.GetComponent<HBDrag>();

        if (CheckDroppedObject(HBDragScript.gameObject.name, gameObject))
        {
            Debug.Log("OnDrop");
            HBDragScript.gameObject.SetActive(false);
        }
        else
        {
            LoseLife();
        }

        if (currentLives <= 0)
        {
            EndGame();
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

    private void EndGame()
    {
        gameOverText.SetActive(true);
    }
}