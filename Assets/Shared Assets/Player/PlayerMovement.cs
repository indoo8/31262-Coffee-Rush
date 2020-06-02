using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius = 0.05f,h_friction_multiplier = 1, lowJumpMultiplier = 2, fallMultiplier = 2, jump_height = 5, max_speed = 20, smoothTime = 0.5f;
    private Vector2 speed = Vector2.down;
    private Transform playerT;
    public Rigidbody2D rb2d;
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

        //fall faster then you jump
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        //hold jump to go higher
        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }


        if (System.Math.Abs(rb2d.velocity.x) > 0.05 && !Input.GetButton("Horizontal"))
        {
            if (rb2d.velocity.x > 0)
            {
                rb2d.velocity += Vector2.left * h_friction_multiplier * Time.deltaTime;
            }
            else
            {
                rb2d.velocity += Vector2.right * h_friction_multiplier * Time.deltaTime;
            }
        }
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

    public void Jump()
    {
        if (grounded)
        {
            rb2d.AddForce(Vector2.up * jump_height, ForceMode2D.Impulse);
            Debug.Log("Jump");
            grounded = false;
        }
    }

    public void Move()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * max_speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref refVel, smoothTime);
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = playerT.localScale;
        scale.x *= -1;
        playerT.localScale = scale;
    }
}
