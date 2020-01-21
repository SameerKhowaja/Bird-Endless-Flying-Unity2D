using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Text startTXT, madeByTXT;
    public Canvas canvas;
    public BirdMovement bm;
    public spawnPoints sp;
    public Transform bird;
    public AudioSource startSound, buttonPress, gameSound;

    private void Start()
    {
        startSound.Play();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void PlayBTN_click()
    {
        buttonPress.Play();
        madeByTXT.enabled = startTXT.enabled = false;
        bm.enabled = true;
        sp.enabled = true;
        canvas.enabled = false;

        bird.transform.position = new Vector3(-3f, 0f, 0f);

        this.enabled = false;
        startSound.Stop();
        gameSound.Play();
    } 
}
