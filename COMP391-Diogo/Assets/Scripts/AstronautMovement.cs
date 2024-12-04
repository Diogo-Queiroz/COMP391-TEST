using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class AstronautMovement : MonoBehaviour
{
    private float horizontaInput;
    private bool jumpPressed = false;
    [Header("Movevement Section")]
    [SerializeField] private AstronautStats stats;

    [Header("Ground Detection")]
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputs inputs;

    private void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Player.Move.performed += context => horizontaInput = context.ReadValue<Vector2>().x;
        inputs.Player.Move.canceled += _ => horizontaInput = 0f; // underscore is a Discard variable placeholder when the variable is unused
        inputs.Player.Jump.started += _ => jumpPressed = true;
        inputs.Player.Jump.canceled += _ => jumpPressed = false;
        EventsExample.debugEvent += DebugMessage;
    }
    private void OnEnable() => inputs.Enable();
    private void OnDisable() => inputs.Disable();

    private void DebugMessage()
    {
        Debug.Log("I am late for the mission. Better run");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();

        // Handle the Jump
        if (jumpPressed && isGrounded)
        {
            // Then I want to jump
            rb.velocity = new Vector2(rb.velocity.x, stats.jumpForce);
        }

        if (!jumpPressed && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        HandleAnimation();
        Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontaInput * stats.speed, rb.velocity.y);
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
            newLocalScale.x = -1f; // It's -1 because the asset is facing left already
        }
        if (horizontaInput < 0f)
        {
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
