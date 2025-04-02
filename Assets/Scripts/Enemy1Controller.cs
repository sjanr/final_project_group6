
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1Controller : MonoBehaviour, IDamageable 
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
    private float knockbackDuration = 0.2f;
    private float knockbackTimer = 0f;

    //initialise enemy
    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.flipX = movingRight;
    }

    private void Update()
    {
        //enemy knockback on hit timer
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
        }
        else
        {
            //call enemy movement methos
            Patrol();
        }
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
            Flip();//flip sprite
        }
    }

    //flip spirit
    private void Flip()
    {
        movingRight = !movingRight;
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = movingRight; 
        }

        //flip the ground check object to otherside of enemy
        if (groundCheck != null)
        {
                Vector3 checkPos = groundCheck.localPosition;
                checkPos.x *= -1f;
                groundCheck.localPosition = checkPos;
        }

    }

    //enemy damge
    public void TakeDamage(int dmg,Vector2 hitDirection)
    {
        //Debug.Log($"{gameObject.name} took {dmg} damage. Current health: {currentHealth}");
        //deal damage
        currentHealth -= dmg;

        //knockback on hit
        float knockbackForce = 5f; 
        rb.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);

        knockbackTimer = knockbackDuration;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //done from side of bullet since bullet tage sometimes does not register
        /*if (collision.collider.CompareTag("bullet"))
        {
            Projectile projectile = collision.collider.GetComponent<Projectile>();
            if (projectile != null)
            {
                Vector2 hitDirection = (transform.position - projectile.transform.position).normalized;
                Debug.Log($"{gameObject.name} hit by projectile with {projectile.damage} damage");
                TakeDamage(projectile.damage, hitDirection);
                Destroy(projectile.gameObject);
            }
        }*/

        //in contact with player load gameover scene- Do not destroy player
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player collided with enemy");
            //Destroy(collision.gameObject);

            GameSession.lastLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOver");
        }
    }

}
