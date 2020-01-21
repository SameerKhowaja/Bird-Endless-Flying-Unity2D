using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public Text GameOverTxt1, GameOverTxt2;
    public AudioSource gameOver;
    public Canvas canvas;

    void Start()
    {
        GameOverTxt1.enabled = true;
        GameOverTxt2.enabled = true;

        StartCoroutine(SceneLoadWait());
    }


    IEnumerator SceneLoadWait()
    {
        gameOver.Play();

        yield return new WaitForSeconds(3f);

        canvas.enabled = true;
    }

    public void RestartBTN()
    {
        SceneManager.LoadScene("lvl01");
    }

}
