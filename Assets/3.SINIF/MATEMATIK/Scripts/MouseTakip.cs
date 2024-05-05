using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class MouseTakip : MonoBehaviour
{
    [SerializeField] private GameObject carryObject;
    [SerializeField] private List<Sprite> ingredientSprites;
    public int toppingInt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = Input.mousePosition;
        Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
        carryObject.transform.position = mousePosition2D;
    }

    public void PickMushroom()
    {
        carryObject.GetComponent<UnityEngine.UI.Image>().sprite = ingredientSprites[3];
        toppingInt = 3;

    }

    public void PickSalami()
    {
        carryObject.GetComponent<UnityEngine.UI.Image>().sprite = ingredientSprites[2];
        toppingInt = 2;

    }
    public void PickOlive()
    {
        carryObject.GetComponent<UnityEngine.UI.Image>().sprite = ingredientSprites[0];
        toppingInt = 0;

    }
    public void PickCorn()
    {
        carryObject.GetComponent<UnityEngine.UI.Image>().sprite = ingredientSprites[1];
        toppingInt = 1;

    }

}
