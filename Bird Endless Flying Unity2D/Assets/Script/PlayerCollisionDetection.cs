using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionDetection : MonoBehaviour
{
    public int Health, Points;
    public Text HealthTxt, PointsTxt, GameOverTxt1, GameOverTxt2;
    public GameObject Bird, Blast;
    public endGame end_Game;
    public AudioSource coinCollectSound, hurtSound;

    public Text HighScoreTXT;
    int highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore_BEF", 0);
        HighScoreTXT.text = PlayerPrefs.GetInt("highscore_BEF", 0).ToString();
        Health = 3;
        Points = 0;
        PointsTxt.text = Points.ToString();
        HealthTxt.text = Health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "coin")
        {
            coinCollectSound.Play();
            Points += 5;
            PointsTxt.text = Points.ToString();

            if(Points > highscore)
            {
                highscore = Points;
                PlayerPrefs.SetInt("highscore_BEF", highscore);
                HighScoreTXT.text = highscore.ToString();
            }
        }

        if (collision.collider.tag == "enemy")
        {
            hurtSound.Play();
            Health -= 1;
            HealthTxt.text = Health.ToString();
        }

        Debug.Log("Health: "+Health+" , Points: "+Points);

    }

    void Update()
    {
        if (Health < 1)
        {
            end_Game.enabled = true;

            GameObject effect = Instantiate(Blast, transform.position, Quaternion.identity);
            Destroy(Bird);
            Destroy(effect, 1.2f);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    


}
