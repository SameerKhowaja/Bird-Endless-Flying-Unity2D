using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    //Script For Both Enemy and Coin

    public float speed;
    Vector3 TargetPos;

    void Start()
    {
        TargetPos = new Vector3(transform.position.x - 30f, transform.position.y, 0f);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, speed * Time.fixedDeltaTime);

        if (transform.position == TargetPos)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
