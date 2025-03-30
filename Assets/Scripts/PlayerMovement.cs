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
    public System.Boolean grounded;

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
