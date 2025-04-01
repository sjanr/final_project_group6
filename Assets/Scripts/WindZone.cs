using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float windForce = 5f;
    private bool playerInside = false;
    private Rigidbody2D playerRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRB = collision.GetComponent<Rigidbody2D>();
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            playerRB = null;
        }
    }

    private void FixedUpdate()
    {
        if (playerInside && playerRB != null)
        {
            playerRB.AddForce(Vector2.right * windForce, ForceMode2D.Force);
        }
    }
}
