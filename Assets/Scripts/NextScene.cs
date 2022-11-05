using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void next()
    {
        SceneManager.LoadScene(0);
    }

    public void toDescription()
    {
        SceneManager.LoadScene(2);
    }

}
