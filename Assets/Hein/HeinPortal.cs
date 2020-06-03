using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeinPortal : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject portalOut;
    [SerializeField]
    private bool flipXSpeed = false;
    [SerializeField]
    private bool flipYSpeed = false;
    private IEnumerator coroutine;
    Vector2 speed = new Vector2();

    
    void Start()
    {
        coroutine = AddSpeed(2.0f);
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        rb = collider.GetComponent<Rigidbody2D>();

        if (collider.gameObject.tag == "Player")
        {
            
            if (flipXSpeed)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                speed = rb.velocity;

            }
            else if(flipYSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
                speed = rb.velocity;
            }

            collider.transform.position = portalOut.transform.position;
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator AddSpeed(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            rb.velocity = speed;
    }
}
