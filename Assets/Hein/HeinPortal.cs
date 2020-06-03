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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        rb = collider.GetComponent<Rigidbody2D>();

        if (collider.gameObject.tag == "Player")
        {
            collider.transform.position = portalOut.transform.position;

            if (flipXSpeed)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }
            else if(flipYSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
        }
    }
}
