using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;

    [Header("Player Speed")]
    [SerializeField] private float speed;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private bool grounded;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        playerBody.linearVelocity = new Vector2(horizontalInput * speed, playerBody.linearVelocity.y);

        // Flip sprite based on movement direction
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Animation parameters
        animator.SetBool("isRunning", Mathf.Abs(horizontalInput) > 0.01f);
        animator.SetBool("isInMidAir", !grounded);

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            animator.Play("Jump", 0, 0f); // Layer 0, time 0
            animator.SetBool("isJumping", true);
        }


        // Reset isJumping once airborne so it doesn't loop
        if (!grounded && animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void Jump()
    {
        playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpHeight);
    }
}
