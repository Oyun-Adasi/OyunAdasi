using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTakip : MonoBehaviour
{
    [SerializeField] private GameObject carryObject;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> ingredientSprites;
    public  int toppingInt ; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 mousePosition2D = new Vector2(worldPosition.x, worldPosition.y);
        carryObject.transform.position = mousePosition2D;
    }

    public void PickMushroom()
    {
        spriteRenderer.sprite =  ingredientSprites[3];
        toppingInt = 3;

    }

    public void PickSalami()
    {
        spriteRenderer.sprite =  ingredientSprites[2];
        toppingInt = 2;

    }
    public void PickOlive()
    {
        spriteRenderer.sprite =  ingredientSprites[0];
        toppingInt = 0;
        
    }
    public void PickCorn()
    {
        spriteRenderer.sprite =  ingredientSprites[1];
        toppingInt = 1;

    }
    
}
