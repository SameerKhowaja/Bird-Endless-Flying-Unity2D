﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public Text GameOverTxt1, GameOverTxt2;
    public AudioSource gameOver;

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

        SceneManager.LoadScene("lvl01");
    }

}
