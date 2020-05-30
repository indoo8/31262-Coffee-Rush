using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private float speed = 0;
    private float x_speed = 0, y_speed = 0;
    [SerializeField] private float groundCheckRadius = 0.1f, gravity = 2, jump_height = 5, friction = 1, acceleration = 1, max_speed = 20, smoothTime = 0.5f;
    private Vector2 speed = Vector2.down;
    private Transform playerT;
    public Rigidbody2D rb2d;
    private bool onGround = false, onWall = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private Vector2 refVel = Vector2.zero;
    [SerializeField] private Animator pAnimator;

    private bool grounded;
    private float xSpeed;
    private bool faceRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerT = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = CheckGrounded();
        xSpeed = rb2d.velocity.x;
        pAnimator.SetBool("grounded", grounded);
        pAnimator.SetFloat("speed", Mathf.Abs(xSpeed));

        if (faceRight && xSpeed < 0)
            Flip();
        if (!faceRight && xSpeed > 0)
            Flip();
        
    }

    public bool CheckGrounded()
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

    public void Jump()
    {
        if (CheckGrounded())
        {
            rb2d.AddForce(Vector2.up * jump_height, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }

    public void Move()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * max_speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref refVel, smoothTime);
    }

    public void Fall()
    {
        
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = playerT.localScale;
        scale.x *= -1;
        playerT.localScale = scale;
    }
}
