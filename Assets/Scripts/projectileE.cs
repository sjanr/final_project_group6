using UnityEngine;
using UnityEngine.SceneManagement;

public class projectileE : MonoBehaviour
{
    public float speed = 5f;
    

    private Vector2 direction;
    private Vector2 startPosition;
    public int damage = 1;
    float maxDistance;

    //majority same as other projectile

    private void Start()
    {
        Vector3 pos = transform.position;
        pos.z = 0f; 
        transform.position = pos;

        startPosition = transform.position;
    }

    public void Init(Vector2 moveDirection,float maxDist)
    {
        
        direction = moveDirection.normalized;
        startPosition = transform.position;
        maxDistance = maxDist;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    // to deal damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by snowflake!");
            //Destroy(other.gameObject); // or call player.TakeDamage()

            Destroy(gameObject);

            SceneManager.LoadScene("GameOver");
        }

        // destroy when hit by a player's projectile
        if (other.CompareTag("bullet"))
        {
            Debug.Log("Snowflake hit by player projectile");
            Destroy(other.gameObject); // destroy the player's projectile
            Destroy(gameObject);       // destroy this snowflake
        }
    }
}
