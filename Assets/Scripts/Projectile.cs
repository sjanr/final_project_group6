
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 10f;

    private Vector2 direction;
    private Vector2 startPosition;
    public int damage = 1;
    

    private void Start()
    {
        Vector3 pos = transform.position;
        pos.z = 0f; 
        transform.position = pos;
        

        //startPosition = transform.position;
    }

    public void Init(Vector2 moveDirection)
    {
        
        direction = moveDirection.normalized;
        startPosition = transform.position;
    }

    //movement of projectile maintained in Init and update
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

        
        if (other.CompareTag("enemy"))
        {
            //check hit on ememy
            IDamageable enemy = other.GetComponent<IDamageable>();            if (enemy != null)
            {
                Vector2 hitDirection = (other.transform.position - transform.position).normalized;
                enemy.TakeDamage(damage, hitDirection);
            }

        }

        //projectile to projectile collision
        if (other.CompareTag("bullet"))
        {Debug.Log("Hit: " + other.tag);

            Destroy(other.gameObject);
            //Destroy(gameObject);
        }

        if (other.CompareTag("checkpoint"))
        {
            //call the damage method on the enemy class
            Debug.Log("Hit: " + other.tag);

            Destroy(other.gameObject);
            //Destroy(gameObject);
        }

        //destory on all collisions
        Destroy(gameObject);
    }

}
