using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2Controller : MonoBehaviour,IDamageable
{
    
    public GameObject snowflakePrefab;
    public Transform firePoint;
    public Vector2 shootDirection = Vector2.left; 
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

    //implemet snowflake projectile shooting
    void Shoot()
    {
        GameObject snowflake = Instantiate(snowflakePrefab, firePoint.position, Quaternion.identity);
        projectileE snowflakeScript = snowflake.GetComponent<projectileE>();

        if (snowflakeScript != null)
        {
            snowflakeScript.Init(shootDirection.normalized, projectileMaxDistance);
        }
    }

    //eventhough hit direction not used passed in due to interface IDamagable
    public void TakeDamage(int dmg,Vector2 hitDirection)
    {
        //Debug.Log($"{gameObject.name} took {dmg} damage. Current health: {currentHealth}");
        currentHealth -= dmg;

        //removed knockback code for enemy 2
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
        //code passed on from enemy1controller
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

        //if contact with player load game over
        if (collision.collider.CompareTag("Player"))
        {
            //Destroy(collision.gameObject); 
            GameSession.lastLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOver");
        }
    }

}
