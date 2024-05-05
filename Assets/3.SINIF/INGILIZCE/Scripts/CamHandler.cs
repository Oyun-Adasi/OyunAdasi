using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraHandler : MonoBehaviour
{
    public RectTransform canvasRectTransform; // Assign this in the inspector

    void LateUpdate()
    {
        if (canvasRectTransform != null)
        {
            // Convert the canvas center from screen space to world space
            Vector2 viewportPosition = new Vector2(0.5f, 0.5f); // Center of the screen
            Vector3 worldPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

            // Update the camera's position to follow the canvas center, 
            // but maintain its current z position.
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }
    }
}

