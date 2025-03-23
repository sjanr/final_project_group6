
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float checkDistance = 1f; 

    private void OnEnable()
    {
        inputHandler.OnAttackInput += TryDestroyBlockAbove;
    }

    private void OnDisable()
    {
        inputHandler.OnAttackInput -= TryDestroyBlockAbove;
    }

    private void TryDestroyBlockAbove()
    {
        // Starting point is player's position
        Vector2 origin = transform.position;

        // Cast upward
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up, checkDistance);

        if (hit.collider != null && hit.collider.CompareTag("block"))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}

