using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class MakeDrink : MonoBehaviour
{
    Rigidbody2D cup;
    // 랜덤 음료수의 이미지
    public Sprite randomDrink;
    // 음료수에 맞는 재료
    public GameObject[] americano;
    public GameObject[] cafeLatte;
    public GameObject[] milkShake;
    public GameObject[] cappuccino;
    public GameObject[] einspanner;
    public GameObject[] strawberryShake;
    public GameObject[] vanillaLatte;
    public GameObject[] cafeMocha;
    public Sprite[] drink;

    // 새로운 음료가 필요한지 확인
    public bool needNewDrink;
    
    // 현재까지 맞게 들어간 재료의 개수 확인
    private int RightIngredient = 0;

    // 맞는 재료가 들어갔는지 확인
    private bool isRightIngredient;

    // 필요한 음료의 개수
    private int needIngredient;

    public GameObject other;

    void Start()
    {
        //Rigidbody2D 요소를 가지고 옴
        cup = GetComponent<Rigidbody2D>();
        needNewDrink = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        CheckIsRightDrink();
        // Americano: espresso, water 
        if (randomDrink == drink[0])
        {
            // 배열에 맞는 재료가 있는지 확인
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

        other.gameObject.SetActive(false);
        CheckMakingDrink(isRightIngredient, needIngredient);
    }

    void Update()
    {
        randomDrink = other.GetComponent<RandomDrink>().GetComponent<SpriteRenderer>().sprite;
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
