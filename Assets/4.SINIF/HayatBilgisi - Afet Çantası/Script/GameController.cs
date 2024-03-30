using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector3 offset;
    new Collider2D collider2D;
    public string destinationTag = "DropArea";
    public bool isRequired;
    public TextMeshProUGUI wrongText;
    public TextMeshProUGUI trueText;
    public GameManager gameManager;

    public int score = 0;

    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Start()
    {
        wrongText.gameObject.SetActive(false);
        trueText.gameObject.SetActive(false);

    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void Update()
    {

    }

    void OnMouseUp()
    {
        collider2D.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;

        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag && isRequired == true)
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
                trueText.gameObject.SetActive(true);
                Invoke("TrueTextSetActiveFalse", 1);
                Destroy(gameObject, 1);

                int requiredObjectLastIndex = gameManager.requiredObject.Count - 1;
                gameManager.requiredObject.RemoveAt(requiredObjectLastIndex);
            }
            else
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
                wrongText.gameObject.SetActive(true);
                Invoke("WrongTextSetActiveFalse", 1);
                Destroy(gameObject, 1);

                int unrequiredObjectLastIndex = gameManager.unrequiredObject.Count - 1;
                gameManager.unrequiredObject.RemoveAt(unrequiredObjectLastIndex);
            }
        }
        collider2D.enabled = true;
    }


    void TrueTextSetActiveFalse()
    {
        trueText.gameObject.SetActive(false);
    }

    void WrongTextSetActiveFalse()
    {
        wrongText.gameObject.SetActive(false);
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

}
