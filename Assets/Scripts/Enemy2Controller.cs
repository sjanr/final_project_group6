using UnityEngine;

public class Enemy2Controller : MonoBehaviour,IDamageable
{
    
    public GameObject snowflakePrefab;
    public Transform firePoint;
    public Vector2 shootDirection = Vector2.left; // Can be changed in Inspector
    public float fireInterval = 2f;
    public float projectileMaxDistance = 15f;


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
        projectileE snowflakeScript = snowflake.GetComponent<projectileE>();

        if (snowflakeScript != null)
        {
            snowflakeScript.Init(shootDirection.normalized, projectileMaxDistance);
        }
    }

    public void TakeDamage(int dmg,Vector2 hitDirection)
    {
        //Debug.Log($"{gameObject.name} took {dmg} damage. Current health: {currentHealth}");
        currentHealth -= dmg;

        //attempt at knockback. does not currently work
        //float knockbackForce = 5f; 
        //rb.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);

        //knockbackTimer = knockbackDuration;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.collider.CompareTag("bullet"))
        {
            Projectile projectile = collision.collider.GetComponent<Projectile>();
            if (projectile != null)
            {
                //Vector2 hitDirection = (transform.position - projectile.transform.position).normalized;
                TakeDamage(projectile.damage,);
                Destroy(projectile.gameObject);
            }
        }*/

        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Player dies on contact
        }
    }

}
