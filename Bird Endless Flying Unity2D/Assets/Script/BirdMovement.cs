using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed, Yinc;
    public float maxHeight, center;
    Vector2 movement;

    void Start()
    {
        center = 0f;
        maxHeight = Yinc;
        movement = new Vector2(transform.position.x, 0f);
    }

    void Update()
    {
        // Mobile Touch System
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touch_pos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch_pos.y > 0 && transform.position.y == center)
            {
                movement = new Vector2(transform.position.x, transform.position.y + Yinc);
            }
            else if (touch_pos.y < 0 && transform.position.y == center)
            {
                movement = new Vector2(transform.position.x, transform.position.y - Yinc);
            }

            if (touch_pos.y > 0 && transform.position.y == -maxHeight || touch_pos.y < 0 && transform.position.y == maxHeight)
            {
                movement = new Vector2(transform.position.x, center);
            }
        }

        // Computer Keyboard System
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y == center)
        {
            movement = new Vector2(transform.position.x, transform.position.y + Yinc);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y == center)
        {
            movement = new Vector2(transform.position.x, transform.position.y - Yinc);
        }

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y == -maxHeight || Input.GetKey(KeyCode.DownArrow) && transform.position.y == maxHeight)
        {
            movement = new Vector2(transform.position.x, center);
        }

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, movement, speed * Time.fixedDeltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -maxHeight, maxHeight);
        transform.position = clampedPosition;

    }

}
