using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI 사용시 필요함
using UnityEngine.UI;

public class RandomDrink : MonoBehaviour
{
    private Image randomDrinkImage;

    // Drink array 생성
    public Sprite[] drink;

    void Start()
    {
    // Component 접근 시 Start() 또는 Awake() 함수에서 미리 선언해야 함
    // 다른 게임 오브젝트에 있는 컴포넌트 접근 시
    // public GameObject other; 선언 후
    // tr = other.GetComponent<Transform>();
    // 또는 Button button = GameObject.FindGameObjectWithTag("게임오브젝트이름").GetComponent<Button>();
        randomDrinkImage = GetComponent<Image>();

    }

    void Update()
    {
        // 8개의 음료수 중 하나가 랜덤으로 나와야 함.
    }

    void ShowRandomDrink()
    {
        // Random을 사용하여 랜덤으로 sprite를 교체해줌.
        int random = Random.Range(0, 8);
        randomDrinkImage.sprite = drink[random];

    }
}
