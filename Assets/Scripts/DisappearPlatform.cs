using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    [SerializeField] private float delayBeforeDisappear = 0.5f;
    [SerializeField] private float reappearDelay = 3f;
    [SerializeField] private bool respawn = false;

    private SpriteRenderer spriteRenderer;
    private Collider2D platformCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke(nameof(Disappear), delayBeforeDisappear);
        }
    }

    private void Disappear()
    {
        spriteRenderer.enabled = false;
        platformCollider.enabled = false;

        if (respawn)
        {
            Invoke(nameof(Reappear), reappearDelay);
        }
    }

    private void Reappear()
    {
        spriteRenderer.enabled = true;
        platformCollider.enabled = true;
    }
}
