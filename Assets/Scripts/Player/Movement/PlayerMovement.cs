using UnityEngine;
using GabrielBigardi.SpriteAnimator;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float maxJumpHoldTime = 0.3f; // Maximum time jump can be held
    public float jumpHoldForce = 5f;    // Additional force while holding jump
    private float jumpHoldTimer;

    [Header("Ground Check")]
    public bool isGrounded;
    public Transform groundCheck; // Reference to ground check position
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // Layer for ground detection

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteAnimator spriteAnimator;

    public bool isJumping;
    private Collider2D currentPlatform; // Reference to the current platform

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        CheckGrounded();
    }

    public void CheckInput()
    {
        // Check for movement input
        Move();
        FlipSprite();

        // Descend input
        if (Input.GetKey(KeyCode.S))
        {
                Debug.Log("Descend input detected");
        }

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.S))
        {
            TryJump();
        }

        if (Input.GetKey(KeyCode.Space) && isJumping && !Input.GetKey(KeyCode.S))
        {
            HoldJump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && !Input.GetKey(KeyCode.S))
        {
            StopJump();
        }
    }

    #region Movement

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            // spriteAnimator.PlayIfNotPlaying("Run");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            // spriteAnimator.PlayIfNotPlaying("Run");
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            // spriteAnimator.Play("Idle");
        }
    }

    private void FlipSprite()
    {
        if (rb.velocity.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void TryJump()
    {
        // Jump only if grounded or vertical velocity is 0
        if (isGrounded && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            StartJump();
        }
    }

    private void StartJump()
    {
        isJumping = true;
        jumpHoldTimer = 0f; // Reset the jump hold timer
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HoldJump()
    {
        if (jumpHoldTimer < maxJumpHoldTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpHoldForce * Time.deltaTime);
            jumpHoldTimer += Time.deltaTime;
        }
    }

    private void StopJump()
    {
        isJumping = false;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    #endregion

    #region Ground Check

    private void CheckGrounded()
    {
        // Check if the player is on the ground using a circle overlap
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    #endregion
}
