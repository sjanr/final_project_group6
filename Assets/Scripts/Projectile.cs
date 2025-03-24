using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 5f;

    private Vector2 direction;
    private Vector2 startPosition;
    public int damage = 1;


    private void Start()
{
    Vector3 pos = transform.position;
    pos.z = 0f; // force it to camera-friendly Z
    transform.position = pos;

    startPosition = transform.position;
}

    public void Init(Vector2 moveDirection)
    {
        //ignore directuion for now
        //direction = moveDirection.normalized;
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)//add or hit condition 
        //hit.collider != null && hit.collider.CompareTag("block")
        {
            Destroy(gameObject);
        }
    }
    // to deal damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            //call the damage method on the enemy class
            Debug.Log("Hit a enemy");
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }

}
