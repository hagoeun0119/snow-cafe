using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrink : MonoBehaviour
{
    public Sprite[] drink;

    // Check Drink
    public bool checkDrink;

    public GameObject other;

    private MakeDrink makeDrink;

    void Start()
    {
        makeDrink = other.GetComponent<MakeDrink>();
    }

    void Update()
    {
        IsRightDrink();
    }

    void IsRightDrink()
    {
        checkDrink = makeDrink.needNewDrink;

        if (checkDrink == true)
        {
            makeDrink.needNewDrink = false;
            // Change Sprite Randomly
            int random = Random.Range(0, 8);
            gameObject.GetComponent<SpriteRenderer>().sprite = drink[random];
        }
    }

}
