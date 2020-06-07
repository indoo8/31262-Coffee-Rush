using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanBanditScript : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius = 0.05f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    // Start is called before the first frame update
    private bool grounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = CheckGrounded();
    }
    private bool CheckGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
