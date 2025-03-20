using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D playerBody;
    private bool grounded;
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
