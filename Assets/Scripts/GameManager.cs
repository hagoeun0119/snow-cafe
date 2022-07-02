using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public float playTime;
    public bool isPlaying;

    public Animator startAnim;
    public Animator clearAnim;
    public Animator background;


    public Text completeMaking;
    public Text playTimeTxt;
    public GameObject gameOver;

    void Start()
    {
        
    }

    public void StageStart() 
    {
        startAnim.SetTrigger("On");
        background.SetTrigger("On");
    }

    void Update()
    {
        Invoke(nameof(CountDown), 5.3f);
    }

    void CountDown() 
    {
        if (isPlaying)
        {
            if (playTime > 0)
            { 
                playTime -= Time.deltaTime;
            }

            int hour = (int)(playTime / 3600);
            int min = (int)((playTime - hour * 3600) / 60);
            int second = (int)(playTime % 60);

            if (hour == 0 && min == 0 && second == 0)
            {
                GameOver();
            }
            playTimeTxt.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StageEnd()
    {
        clearAnim.SetTrigger("On");
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }
}
