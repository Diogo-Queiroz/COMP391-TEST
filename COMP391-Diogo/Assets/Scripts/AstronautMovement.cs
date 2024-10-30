using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AstronautMovement : MonoBehaviour
{
    private float horizontaInput;
    [Header("Movevement Section")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("Flip Player on X")]
    [SerializeField] private bool isFacingRight = true;

    [Header("Ground Detection")]
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontaInput = Input.GetAxis("Horizontal");
        CheckGround();

        // Handle the Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Then I want to jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        HandleAnimation();
        Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontaInput * speed, rb.velocity.y);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundMask);
    }

    void Flip()
    {
        Vector3 newLocalScale = transform.localScale;

        if (horizontaInput > 0f)
        {
            isFacingRight = true;
            newLocalScale.x = -1f; // It's -1 because the asset is facing left already
        }
        if (horizontaInput < 0f)
        {
            isFacingRight = false;
            newLocalScale.x = 1f;
        }

        transform.localScale = newLocalScale;
    }

    void HandleAnimation()
    {
        animator.SetBool("IsWalking", horizontaInput != 0.0f);
        animator.SetBool("IsJumping", !isGrounded);
    }
}
