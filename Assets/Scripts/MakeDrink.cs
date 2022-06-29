using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class MakeDrink : MonoBehaviour
{
    // tag�� ���� ������
    Rigidbody2D cup;
    // �������� �����ϴ� UI ��Ҹ� ������ 
    private Image randomDrink;
    // ��Ḧ �迭�� ����
    public GameObject[] americano;
    public GameObject[] cafeLatte;
    public GameObject[] milkShake;
    public GameObject[] cappuccino;
    public GameObject[] einspanner;
    public GameObject[] strawberryShake;
    public GameObject[] vanillaLatte;
    public GameObject[] cafeMocha;
    // ������� �迭�� ����
    public Sprite[] drink;
    
    // ��� ���� ����
    private int checkIngredient = 0;

    // �ش�Ǵ� ������� Ȯ��
    private bool isRightIngredient;

    // �ʿ��� ����� ����
    private int needIngredient;

    void Start()
    {
        //Rigidbody2D�� ����
        cup = GetComponent<Rigidbody2D>();
        randomDrink = GameObject.FindWithTag("randomDrink").GetComponent<Image>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Americano: espresso, water 
        if (randomDrink == drink[0])
        {
            // �浹�� ��ᰡ �迭�� �ִ��� Ȯ��
            isRightIngredient = Array.Exists(americano, x => x == other.gameObject);
            needIngredient = americano.Length;
        }

        // Cafe latte: espresso, milk 
        else if (randomDrink == drink[1])
        {
            isRightIngredient = Array.Exists(cafeLatte, x => x == other.gameObject);
            needIngredient = cafeLatte.Length;
        }

        // Milk shake: ice cream, milk, ice
        else if (randomDrink == drink[2])
        {
            isRightIngredient = Array.Exists(milkShake, x => x == other.gameObject);
            needIngredient = milkShake.Length;
        }

        // Cappuccino: espresso, milk, cinnamon
        else if (randomDrink == drink[3])
        {
            isRightIngredient = Array.Exists(cappuccino, x => x == other.gameObject);
            needIngredient = cappuccino.Length;
        }

        // einspanner: water, coffee powder, cream
        else if (randomDrink == drink[4])
        {
            isRightIngredient = Array.Exists(einspanner, x => x == other.gameObject);
            needIngredient = einspanner.Length;
        }

        // Vanilla latte: syrup, espresso, milk, cream
        else if (randomDrink == drink[5])
        {
            isRightIngredient = Array.Exists(vanillaLatte, x => x == other.gameObject);
            needIngredient = vanillaLatte.Length;
        }

        // Strawberry shake: milk, strawberry, cream, ice
        else if (randomDrink == drink[6])
        {
            isRightIngredient = Array.Exists(strawberryShake, x => x == other.gameObject);
            needIngredient = strawberryShake.Length;
        }

        // Mocha latte: syrup, espresso, milk, choco syrup
        else if (randomDrink == drink[7])
        {
            isRightIngredient = Array.Exists(cafeMocha, x => x == other.gameObject);
            needIngredient = cafeMocha.Length;
        }

        CountIngredient(isRightIngredient);
        FinishMakingDrinks(needIngredient);

        void CountIngredient(bool check)
        {
            other.gameObject.SetActive(false);
            if (check == true)
            {
                checkIngredient += 1;
            }
            else
            {
                Debug.Log("����");
            }
        }

        void FinishMakingDrinks(int ingredient)
        {
            if (checkIngredient == ingredient)
            {
                Debug.Log("�ϼ�");

            }
        }

    }

    void Update()
    {
            // �־��� �ð�����
            //OnCollisionEnter2D(); ����
    }
}
