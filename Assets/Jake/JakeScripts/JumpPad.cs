using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    bool isBounce;
    GameObject player;
    public Animator anim;
    //public float bigJump;
    //public Rigidbody2D rb;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isBounce)
        {
            anim.SetBool("Spring", true);
            player = collision.gameObject;
        }
        else
        {
            anim.SetBool("Spring", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isBounce = true;
        //Debug.Log(isBounce);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isBounce = false;
        //Debug.Log(isBounce);
    }

    void willBounce()
    {
            player.GetComponent<Rigidbody2D>().velocity = velocity;
            Debug.Log("Bouncing");
    }
}
