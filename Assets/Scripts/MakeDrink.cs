using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class MakeDrink : MonoBehaviour
{
    Rigidbody2D cup;

    public Sprite randomDrink;
    // ingredients
    public GameObject[] americano;
    public GameObject[] cafeLatte;
    public GameObject[] milkShake;
    public GameObject[] cappuccino;
    public GameObject[] einspanner;
    public GameObject[] strawberryShake;
    public GameObject[] vanillaLatte;
    public GameObject[] cafeMocha;
    public GameObject[] materials;
    public Sprite[] drink;

    public bool needNewDrink;

    // Check the number of materials that is right
    private int RightIngredient = 0;
    private bool isRightIngredient;

    // Check the number of ingredient that is needed
    private int needIngredient;
    private Vector3 materialPos;
    private SpriteRenderer randomDrinkSprite;

    public GameObject other;

    

    void Start()
    {
        cup = GetComponent<Rigidbody2D>();
        randomDrinkSprite = other.GetComponent<RandomDrink>().GetComponent<SpriteRenderer>();
        needNewDrink = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        materialPos = other.gameObject.GetComponent<DragNDrop>().colliderPos;
        var collisoinObj = other.gameObject;

        CheckIsRightDrink();

        // Americano: espresso, water 
        if (randomDrink == drink[0])
        {
            isRightIngredient = Array.Exists(americano, x => x == other.gameObject);
        }

        // Cafe latte: espresso, milk 
        else if (randomDrink == drink[1])
        {
            isRightIngredient = Array.Exists(cafeLatte, x => x == other.gameObject);
        }

        // Milk shake: ice cream, milk, ice
        else if (randomDrink == drink[2])
        {
            isRightIngredient = Array.Exists(milkShake, x => x == other.gameObject);
        }

        // Cappuccino: espresso, milk, cinnamon
        else if (randomDrink == drink[3])
        {
            isRightIngredient = Array.Exists(cappuccino, x => x == other.gameObject);
        }

        // einspanner: water, coffee powder, cream
        else if (randomDrink == drink[4])
        {
            isRightIngredient = Array.Exists(einspanner, x => x == other.gameObject);
        }

        // Vanilla latte: syrup, espresso, milk, cream
        else if (randomDrink == drink[5])
        {
            isRightIngredient = Array.Exists(strawberryShake, x => x == other.gameObject);
        }
        

        // Strawberry shake: milk, strawberry, cream, ice
        else if (randomDrink == drink[6])
        {
            isRightIngredient = Array.Exists(vanillaLatte, x => x == other.gameObject);
        }

        // Mocha latte: syrup, espresso, milk, choco syrup
        else if (randomDrink == drink[7])
        {
            isRightIngredient = Array.Exists(cafeMocha, x => x == other.gameObject);
        }

        CheckMakingDrink(isRightIngredient, needIngredient);
        GameObject newMaterial = Instantiate(collisoinObj, materialPos, Quaternion.identity);
        Destroy(other.gameObject);
    }

    void Update()
    {
        randomDrink = randomDrinkSprite.sprite;
    }
    void CheckIsRightDrink()
    {
        if (randomDrink == drink[0] || randomDrink == drink[1])
        {
            Debug.Log("2");
            needIngredient = 2;
        }
        else if (randomDrink == drink[2] || randomDrink == drink[3] || randomDrink == drink[4])
        {
            Debug.Log("3");
            needIngredient = 3;
        }
        else if (randomDrink == drink[5] || randomDrink == drink[6] || randomDrink == drink[7])
        {
            Debug.Log("4");
            needIngredient = 4;
        }
    }

    void CheckMakingDrink(bool check, int ingredient)
    {
        if (check == true)
        {
            RightIngredient += 1;
            Debug.Log("Right Ingredient");

            if (ingredient == RightIngredient)
            {
                Debug.Log("You made drink");
                RightIngredient = 0;
                needNewDrink = true;
            }
        }
        else
        {
            Debug.Log("Wrong Ingredient");
            needNewDrink = true;
        }
    }
}
