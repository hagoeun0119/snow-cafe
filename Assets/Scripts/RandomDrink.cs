using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI 사용시 필요함
using UnityEngine.UI;

public class RandomDrink : MonoBehaviour
{
    public Sprite[] drink;

    // 음료를 다 만들었는지 확인 가능
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
            // Random을 사용하여 랜덤으로 sprite를 교체해줌.
            int random = Random.Range(0, 8);
            gameObject.GetComponent<SpriteRenderer>().sprite = drink[random];
        }
    }

}
