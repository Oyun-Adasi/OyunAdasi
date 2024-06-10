using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


// Attach this script to an empty GameObject.
// When you click on a sprite with a collider, it will change its ingredient and update the ingredient counts.
public class IngredientChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> slices;
    List<bool> isOccupied = new List<bool>(9);
    private int colliderNumber = 0;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer sliceRenderer;
    [SerializeField] private MouseTakip _mouseTakip;
    public int spriteInt = 4;
    [SerializeField] private List<Sprite> ingredientSprites;
    [SerializeField] private int mushroom;
    [SerializeField] private int salami;
    [SerializeField] private int olive;
    [SerializeField] private int corn;
    [SerializeField] private int mushroomDesired;
    [SerializeField] private int salamiDesired;
    [SerializeField] private int oliveDesired;
    [SerializeField] private int cornDesired;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Text conditionText;
    [SerializeField] private int score;

    private void Start()
    {
        RandomizeIngredients();
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                colliderNumber = int.Parse(hit.collider.tag);
                if (isOccupied[colliderNumber])
                {
                    IngredientDeCounter();
                }
                else
                {
                    isOccupied[colliderNumber] = true;
                    spriteInt = _mouseTakip.toppingInt;
                    Debug.Log(hit.collider + " " + colliderNumber);
                    spriteRenderer = slices[colliderNumber].GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = ingredientSprites[spriteInt];
                    if (spriteRenderer != null)
                    {
                        IngredientCounter();

                    }
                }
            }
            else if (hit.collider == null)
            {
                spriteInt = 4;
            }
        }
    }

    void IngredientCounter()
    {
        if (spriteInt == 1)
        {
            olive++;
        }
        else if (spriteInt == 2)
        {
            corn++;
        }
        else if (spriteInt == 3)
        {
            salami++;
        }
        else if (spriteInt == 4)
        {
            mushroom++;
        }
    }

    void IngredientDeCounter()
    {
        if (spriteInt == 1)
        {
            olive--;
        }
    else if (spriteInt == 2)
        {
            corn--;
        }
    else if (spriteInt == 3)
        {
            salami--;
        }
    else if (spriteInt == 4)
        {
            mushroom--;
        }
    }

    void RandomizeIngredients()
    {
        List<int> ingredientValues = new List<int> { olive, corn, salami, mushroom };
        int totalValue = 8;

        // Randomize the ingredient values
        for (int i = 0; i < ingredientValues.Count - 1; i++)
        {
            int randomValue = Random.Range(1, totalValue - (ingredientValues.Count - i - 1) + 1);
            ingredientValues[i] = randomValue;
            totalValue -= randomValue;
        }

        // Assign the remaining value to the last ingredient
        ingredientValues[ingredientValues.Count - 1] = totalValue;

        // Update the ingredient counts
        oliveDesired = ingredientValues[0];
        cornDesired = ingredientValues[1];
        salamiDesired = ingredientValues[2];
        mushroomDesired = ingredientValues[3];

        conditionText.text = cornDesired + "/8 Corn " + mushroomDesired + "/8 Mushroom " + salamiDesired + "/8 Salami " +
                             oliveDesired + "/8 Olive ";
    }
    public void ResetGame()
    {

        olive = 0;
        corn = 0;
        salami = 0;
        mushroom = 0;


        spriteInt = 4;


        for (int i = 0; i < 9; i++)
        {
            sliceRenderer = slices[i].GetComponent<SpriteRenderer>();
            sliceRenderer.sprite = null;
        }



    }

    public void CheckIngredients()
    {
        bool ingredientsCorrect = olive == oliveDesired &&
                                  corn == cornDesired &&
                                  salami == salamiDesired &&
                                  mushroom == mushroomDesired;

        if (ingredientsCorrect)
        {
            winScreen.SetActive(true);
            score = score + 10;
        }
        else
        {
            loseScreen.SetActive(true);
            score = score - 10;
        }
    }
    public void NextQuestion()
    {

        olive = 0;
        corn = 0;
        salami = 0;
        mushroom = 0;


        spriteInt = 4;


        for (int i = 0; i < 9; i++)
        {
            sliceRenderer = slices[i].GetComponent<SpriteRenderer>();
            sliceRenderer.sprite = null;
        }

        RandomizeIngredients();
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

}
