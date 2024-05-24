using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityRaycast : MonoBehaviour
{
    public CityUIManager uiManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

            if (hit.collider != null)
            {
                City il = hit.collider.GetComponent<City>();
                if (il != null)
                {
                    il.uiManager = uiManager;
                    il.OnClicked();
                }
            }
        }
    }
}
