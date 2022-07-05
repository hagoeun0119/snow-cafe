using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MakeDrink : MonoBehaviour
{
    public GameObject completeTxt;
    public GameObject other;
    public Sprite randomDrink;
    public Sprite[] drink;
    public bool needNewDrink;
    public int score;
    
    private int[] countIngredient;
    private Vector3 materialPos;
    private SpriteRenderer randomDrinkSprite;

    void Start()
    {
        randomDrinkSprite = other.GetComponent<RandomDrink>().GetComponent<SpriteRenderer>();
        needNewDrink = true;
        countIngredient = new int[4] { 0, 0, 0, 0 };
    }

    void Update()
    {
        randomDrink = randomDrinkSprite.sprite;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        materialPos = other.gameObject.GetComponent<DragNDrop>().colliderPos;
        GameObject collisionObj = other.gameObject;

        Instantiate(collisionObj, materialPos, Quaternion.identity);
        Destroy(other.gameObject);

        // Americano: espresso, water
        if (randomDrink == drink[0])
            switch (collisionObj.tag)
            {
                case "Espresso":
                    countIngredient[0] += 1;
                    break;
                case "Water":
                    countIngredient[1] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        // Cafe latte: espresso, milk 
        else if (randomDrink == drink[1])
            switch (collisionObj.tag)
            {
                case "Espresso":
                    countIngredient[0] += 1;
                    break;
                case "Milk":
                    countIngredient[1] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        // Milk shake: ice cream, milk, ice
        else if (randomDrink == drink[2])
            switch (collisionObj.tag)
            {
                case "IceCream":
                    countIngredient[0] += 1;
                    break;
                case "Milk":
                    countIngredient[1] += 1;
                    break;
                case "IceBox":
                    countIngredient[2] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        // Cappuccino: espresso, milk, cinnamon
        else if (randomDrink == drink[3])
            switch (collisionObj.tag)
            {
                case "Espresso":
                    countIngredient[0] += 1;
                    break;
                case "Milk":
                    countIngredient[1] += 1;
                    break;
                case "Cinnamon":
                    countIngredient[2] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        // einspanner: water, coffee powder, cream
        else if (randomDrink == drink[4])
            switch (collisionObj.tag)
            {
                case "Water":
                    countIngredient[0] += 1;
                    break;
                case "CoffeePowder":
                    countIngredient[1] += 1;
                    break;
                case "Cream":
                    countIngredient[2] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        // Strawberry shake: milk, strawberry, cream, ice
        else if (randomDrink == drink[5])
            switch (collisionObj.tag)
            {
                case "Milk":
                    countIngredient[0] += 1;
                    break;
                case "Strawberry":
                    countIngredient[1] += 1;
                    break;
                case "Cream":
                    countIngredient[2] += 1;
                    break;
                case "IceBox":
                    countIngredient[3] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        // Vanilla latte: syrup, espresso, milk, cream
        else if (randomDrink == drink[6])
            switch (collisionObj.tag)
            {
                case "Syrup":
                    countIngredient[0] += 1;
                    break;
                case "Espresso":
                    countIngredient[1] += 1;
                    break;
                case "Milk":
                    countIngredient[2] += 1;
                    break;
                case "Cream":
                    countIngredient[3] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }
        // Cafe Mocha: syrup, espresso, milk, choco syrup
        else if (randomDrink == drink[7])
            switch (collisionObj.tag)
            {
                case "Syrup":
                    countIngredient[0] += 1;
                    break;
                case "Espresso":
                    countIngredient[1] += 1;
                    break;
                case "Milk":
                    countIngredient[2] += 1;
                    break;
                case "ChocolateSyrup":
                    countIngredient[3] += 1;
                    break;
                default:
                    needNewDrink = true;
                    break;
            }

        CheckMakingDrink();
    }

    void CheckMakingDrink()
    {
        if (randomDrink == drink[0] || randomDrink == drink[1])
        {
            if (countIngredient[0] == 1 && countIngredient[1] == 1)
            {
                needNewDrink = true;
                score -= 1;
                StartCoroutine(ShowTxt());
                
            }
        }
        else if ((randomDrink == drink[2]) || (randomDrink == drink[3]) || (randomDrink == drink[4]))
        {
            if ((countIngredient[0] == 1) && (countIngredient[1] == 1) && (countIngredient[2] == 1))
            {
                needNewDrink = true;
                score -= 1;
                StartCoroutine(ShowTxt());
                
            }
        }
        else if ((randomDrink == drink[5]) || (randomDrink == drink[6]) || (randomDrink == drink[7]))
        {
            if ((countIngredient[0] == 1) && (countIngredient[1] == 1) && (countIngredient[2] == 1) && (countIngredient[3] == 1))
            {
                needNewDrink = true;
                score -= 1;
                StartCoroutine(ShowTxt());
                
            }
        }

        if (countIngredient[0] > 1 || countIngredient[1] > 1 || countIngredient[2] > 1 || countIngredient[3] > 1)
            needNewDrink = true;

        if (needNewDrink == true)
            countIngredient = new int[4] { 0, 0, 0, 0 };
    }

    IEnumerator ShowTxt()
    {
        completeTxt.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        completeTxt.SetActive(false);
    }
    
}
