using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public float playTime;
    public float recipeShowTime;
    public bool isPlaying;
    public int stage;
    public int nextScore;

    public Animator startAnim;
    public Animator clearAnim;
    public Animator backgroundAnim;
    public Text playTimeTxt;
    public Text stageTxt;
    public Text coffeeTxt;
    public GameObject recipeBackground;
    public GameObject clearTxt;
    public GameObject recipeImg;
    public GameObject recipeBtn;
    public GameObject gameOver;
    public GameObject gameClear;
    public GameObject other;

    private MakeDrink makeDrink;

    void Start()
    {
        makeDrink = other.GetComponent<MakeDrink>();
        nextScore = makeDrink.score;
        StageStart();
    }

    public void StageStart() 
    {
        startAnim.SetTrigger("On");
        startAnim.GetComponent<Text>().text = "Stage " + stage + "\nStart";
        clearAnim.GetComponent<Text>().text = "Stage " + stage + "\nClear!";
        backgroundAnim.SetTrigger("On");
        isPlaying = true;
        Invoke(nameof(ShowRecipeBtn), 5.5f);
    }

    public void StageEnd()
    {
        clearTxt.SetActive(true);
        clearAnim.SetTrigger("On");
        backgroundAnim.SetTrigger("On");
        recipeBtn.SetActive(false);

        isPlaying = false;
        stage++;
        Invoke(nameof(StageStart), 5.3f);
    }

    void Update()
    {
        if (isPlaying == true)
        {
            Invoke(nameof(CountDown), 5.3f);
        }
    }

    private void LateUpdate()
    {
        coffeeTxt.text = "x " + makeDrink.score.ToString();
        stageTxt.text = "Stage " + stage;
    }

    public void ClickRecipeBtn() 
    {
        StartCoroutine(ShowAndHideRecipe());
    }

    IEnumerator ShowAndHideRecipe()
    {
        recipeImg.SetActive(true);
        recipeBackground.SetActive(true);
        yield return new WaitForSeconds(1f);
        recipeImg.SetActive(false);
        recipeBackground.SetActive(false);
    }

    public void ShowRecipeBtn()
    {
        recipeBtn.SetActive(true);
    }

    void CountDown() 
    {
        if (isPlaying)
        {
            if (playTime > 0)
            {
                playTime -= Time.deltaTime;
                if (stage < 5 && makeDrink.score == 0)
                {
                    nextScore += nextScore;
                    makeDrink.score += 1;
                    StageEnd();
                }
                else if (stage == 5 && makeDrink.score == 0)
                {
                    GameClear();
                }
            }
            else
            {
                GameOver();
            }

            int hour = (int)(playTime / 3600);
            int min = (int)((playTime - hour * 3600) / 60);
            int second = (int)(playTime % 60);

            playTimeTxt.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void GameClear()
    {
        gameClear.SetActive(true);
    }
}
