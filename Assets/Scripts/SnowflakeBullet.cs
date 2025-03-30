using UnityEngine;

public class SnowflakeBullet : MonoBehaviour
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

    startPosition = transform.position;
}

    public void Init(Vector2 moveDirection)
    {
        
        direction = moveDirection.normalized;
        startPosition = transform.position;
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
        if (other.CompareTag("enemy"))
        {
            //check hot on ememy
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                Vector2 hitDirection = (enemy.transform.position - transform.position).normalized;
                enemy.TakeDamage(damage, hitDirection);
            }

        }

        Destroy(gameObject);
    }

}
