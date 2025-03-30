using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    
    public GameObject snowflakePrefab;
    public Transform firePoint;
    public Vector2 shootDirection = Vector2.left; // Can be changed in Inspector
    public float fireInterval = 2f;

    public int maxHealth = 3;
    private int currentHealth;
    private float fireTimer = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        fireTimer = fireInterval;
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireInterval;
        }
    }

    void Shoot()
    {
        GameObject snowflake = Instantiate(snowflakePrefab, firePoint.position, Quaternion.identity);
        Projectile snowflakeScript = snowflake.GetComponent<Projectile>();

        if (snowflakeScript != null)
        {
            snowflakeScript.Init(shootDirection.normalized);
        }
    }

    public void TakeDamage(int dmg, Vector2 hitDirection)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Player dies on contact
        }
    }

}
