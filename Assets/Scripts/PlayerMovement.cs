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

if (horizontalInput > 0.01f)
{
    transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f); // Facing right
}
else if (horizontalInput < -0.01f)
{
    transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Facing left
}


    animator.SetBool("isRunning", Mathf.Abs(horizontalInput) > 0.01f);

    if (Input.GetKey(KeyCode.Space) && grounded)
    {
        Jump();
    }
}


    private void Jump()
    {
        playerBody.linearVelocity = new Vector2(playerBody.linearVelocity.x, jumpHeight);
    }

}
