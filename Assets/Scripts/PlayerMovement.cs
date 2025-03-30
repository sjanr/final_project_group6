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
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        playerBody.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerBody.linearVelocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3((float)-0.5, (float)0.5, (float)0.5);
        }
        if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
        }

        animator.SetBool("isRunning", Mathf.Abs(horizontalInput) > 0.01f);
        animator.SetBool("isInMidAir", !grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            animator.Play("Jump", 0, 0f);
            animator.SetBool("isJumping", true);
        }

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
