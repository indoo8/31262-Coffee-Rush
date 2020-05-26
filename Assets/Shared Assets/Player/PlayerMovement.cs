using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private float speed = 0;
    private float x_speed = 0, y_speed = 0;
    public float gravity = 2, jump_height = 5, friction = 1, acceleration = 1, max_speed = 20;
    private Vector2 speed = Vector2.down;
    private Transform playerT;
    public Rigidbody2D rb2d;
    private bool onGround = false, onWall = false;

    // Start is called before the first frame update
    void Start()
    {
        playerT = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*playerT.Translate(speed * Time.deltaTime);
        if (speed.x > 0)
        {
            speed.x -= friction * Time.deltaTime;
        }
        else
        {
            speed.x += friction * Time.deltaTime;
        }
        speed.y -= gravity * Time.deltaTime;
        */
    }

    private void Checkgrounded()
    {

    }

    public void Move(float direction)
    {
        /*
        Vector2 hVel = rb2d.velocity;
        hVel.x += direction * acceleration * Time.deltaTime;
        hVel.x = Mathf.Clamp(hVel.x, max_speed*-1, max_speed);
        rb2d.velocity.Set(hVel.x, hVel.y);
        */

    }

    public void Move(Vector2 direction)
    {
        rb2d.AddForce(direction * acceleration * Time.deltaTime, ForceMode2D.Impulse);
        Debug.Log("move");
    }

    public void Jump()
    {
        //speed.y += jump_height;
        rb2d.AddForce(Vector2.up * jump_height, ForceMode2D.Impulse);
        Debug.Log("Jump");
    }

    public void Fall()
    {
        
    }
}
