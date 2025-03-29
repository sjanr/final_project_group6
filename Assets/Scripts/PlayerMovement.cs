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
    [SerializeField] private Animator animator;
    private bool grounded;
    
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

private void Update()
{
    grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    float horizontalInput = Input.GetAxis("Horizontal");
    playerBody.linearVelocity = new Vector2(horizontalInput * speed, playerBody.linearVelocity.y);

    // Flip sprite
    if (horizontalInput > 0.01f)
        transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
    else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    // Animations
    animator.SetBool("isRunning", Mathf.Abs(horizontalInput) > 0.01f);
    animator.SetBool("isJumping", !grounded); // <- Set jump animation when NOT grounded

    // Jump input
    if (Input.GetKeyDown(KeyCode.Space) && grounded)
    {
        Jump();
        animator.SetBool("isJumping", true); // Force jump animation
    }

    // Reset animation state on land
    if (grounded)
    {
        animator.SetBool("isJumping", false);
    }

}
    private void Jump()
    {
        playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpHeight);
    }

}
