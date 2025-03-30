using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int maxHealth = 3;

    private int currentHealth;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1f;

    private bool movingRight = true;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Patrol();
    }

    //used for movement
    private void Patrol()
    {
        float move = movingRight ? 1 : -1;
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        //check ground- if nop ground in front turn around
        Vector2 checkPosition = groundCheck.position + Vector3.right * (movingRight ? 1f : -1f) * 0.5f;
        RaycastHit2D groundInfo = Physics2D.Raycast(checkPosition, Vector2.down, groundCheckDistance, groundLayer);

        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    //flip spirit
    private void Flip()
    {
        movingRight = !movingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    //enemy damge
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Later replace with player death logic if needed
        }
    }
}
