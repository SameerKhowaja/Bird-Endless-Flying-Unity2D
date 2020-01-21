using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoints : MonoBehaviour
{
    public GameObject enemyPrefab, coinPrefab;
    public Transform[] points;
    public PlayerCollisionDetection playerCollisionDetection;
    int RandomOut, CoinCheck;
    public float StartTime = 1f;
    public float IntervalTime = 1.5f;

    void Update()
    {
        if (Time.time >= StartTime)
        {
            GeneratingPrefabAsEnemy();
            StartTime = Time.time + IntervalTime;
        }

        if (playerCollisionDetection.Points > 100 && playerCollisionDetection.Points < 200)
        {
            IntervalTime = 1.3f;
        }
        else if (playerCollisionDetection.Points > 200 && playerCollisionDetection.Points < 300)
        {
            IntervalTime = 1.1f;
        }
        else if (playerCollisionDetection.Points > 300 && playerCollisionDetection.Points < 400)
        {
            IntervalTime = 0.9f;
        }
        else if (playerCollisionDetection.Points > 400)
        {
            IntervalTime = 0.82f;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    void GeneratingPrefabAsEnemy()
    {
        RandomOut = Random.Range(0, points.Length);
        CoinCheck = Random.Range(0, 2);
        //Debug.Log(RandomOut);
        for (int i = 0; i < points.Length; i++)
        {
            if (i != RandomOut)
            {
                Instantiate(enemyPrefab, points[i].position, Quaternion.identity);
                if (CoinCheck == 1)
                {
                    Instantiate(coinPrefab, points[RandomOut].position, Quaternion.identity);
                }
            }
        }
    }
}
