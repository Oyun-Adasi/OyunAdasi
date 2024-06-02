using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class ObjectMatchingGame : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int matchId;
    private bool isDragging;
    private Vector3 endPoint;
    private ObjectMatchFrom objectMatchFrom;

    [SerializeField] private TextMeshProUGUI scoreText; // Reference to TextMeshProUGUI for the score
    [SerializeField] private TextMeshProUGUI finalScoreText; // Reference to TextMeshProUGUI for the final score

    private int score = 0; // Variable to track the player's score
    private int totalMatches = 0; // Variable to track total matches required to finish the game
    private int currentMatches = 0; // Variable to track current matches

    public bool IsMatched { get; private set; } // Eşleşme durumunu izlemek için

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        finalScoreText.gameObject.SetActive(false); // Hide final score text at the start

        // Count the total number of matches in the scene
        ObjectMatchingGame[] matchingObjects = FindObjectsOfType<ObjectMatchingGame>();
        totalMatches = matchingObjects.Length / 2; // Assuming each pair consists of two matching objects

        UpdateScoreText(); // Initialize the score display
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                lineRenderer.SetPosition(0, mousePosition);
            }
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            lineRenderer.SetPosition(1, mousePosition);
            endPoint = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(endPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.TryGetComponent(out objectMatchFrom) && matchId == objectMatchFrom.Get_ID())
            {
                Debug.Log("Correct From!");
                IsMatched = true;
                OnCorrectMatch(); // Doğru eşleşme olduğunda işlem yap
                this.enabled = false;
            }
            else
            {
                Debug.Log("Wrong Match!");
                OnIncorrectMatch(); // Yanlış eşleşme olduğunda işlem yap
                lineRenderer.positionCount = 0;
            }
            lineRenderer.positionCount = 2;
        }
    }

    private void OnCorrectMatch()
    {
        score++; // Increment score
        currentMatches++;
        UpdateScoreText(); // Update the score display

        if (currentMatches == totalMatches)
        {
            ShowFinalScore();
        }
    }

    private void OnIncorrectMatch()
    {
        score--; // Decrement score
        UpdateScoreText(); // Update the score display
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the score display
    }

    private void ShowFinalScore()
    {
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + score; // Display the final score

        // Optionally, hide other UI elements if necessary
        // For example, you might want to disable the scoreText or other game elements
        scoreText.gameObject.SetActive(false);
    }
}
