using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpPad : MonoBehaviour
{
    bool isBounce;
    GameObject player;
    public Animator anim;
    //public float bigJump;
   // public Rigidbody2D rb;
    public Vector2 velocity;
    //public BoxCollider2D bounceTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //bounceTrigger = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
       //rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnCollisionStay2D(Collision2D collision)
    //{
      //  if (isBounce)
     //   {
     //       anim.SetBool("Spring", true);
     //       player = collision.gameObject;
    //    }
    //    else
    //    {
    //        anim.SetBool("Spring", false);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBounce = true;
        }
        player = collision.gameObject;
        if (isBounce)
        {
            anim.SetBool("Spring", true);
            willBounce();
        }
       
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isBounce = false;
        if(isBounce == false)
        {
            anim.SetBool("Spring", false);
        }
        //Debug.Log(isBounce);
    }

    void willBounce()
    {
            player.GetComponent<Rigidbody2D>().velocity = velocity;
            Debug.Log("Bouncing");
        //StartCoroutine("PostBounce");
    }

   // IEnumerator PostBounce()
   // {
     //   yield return new WaitForSeconds(1);
    //    isBounce = false;
   // }
}
