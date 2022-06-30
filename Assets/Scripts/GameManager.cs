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
            playTime -= Time.deltaTime;

            int hour = (int)(playTime / 3600);
            int min = (int)((playTime - hour * 3600) / 60);
            int second = (int)(playTime % 60);

            playTimeTxt.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);
        }
    }

    public void StageEnd()
    {
        clearAnim.SetTrigger("On");

    }
}
