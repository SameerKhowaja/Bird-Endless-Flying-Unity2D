using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Text startTXT;
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
        if (Input.anyKey)
        {
            buttonPress.Play();
            startTXT.enabled = false;
            bm.enabled = true;
            sp.enabled = true;

            bird.transform.position = new Vector3(-3f, 0f, 0f);

            this.enabled = false;
            startSound.Stop();
            gameSound.Play();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
