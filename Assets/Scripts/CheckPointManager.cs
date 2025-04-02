using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour, IDamageable
{
    public int hitsRequired = 3; // Default value for Level 1
    private int currentHits;

    private void Start()
    {
        // Adjust hitsRequired depending on the scene
        string scene = SceneManager.GetActiveScene().name;

        if (scene.Equals("Level2v2Audio"))
        {
            hitsRequired = 4;
        }

        currentHits = hitsRequired;
    }

    // Called by Projectile.cs when hit
    public void TakeDamage(int dmg, Vector2 hitDirection)
    {
        currentHits -= dmg;
        Debug.Log("Checkpoint hit! Remaining hits: " + currentHits);

        if (currentHits <= 0)
        {
            ProceedToNextScene();
        }
    }

    // Optional: player touching the ghost still triggers Game Over
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the checkpoint ghost — GAME OVER!");
            GameSession.lastLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void ProceedToNextScene()
    {
        Debug.Log("Checkpoint defeated — moving to next scene!");
        GameSession.lastLevel = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;

        if (SceneManager.GetActiveScene().name.Equals("Level1v1Audio"))
        {
            SceneManager.LoadScene("Level2v2Audio");
        }
        else
        {
            SceneManager.LoadScene("GameSuccess");
        }
    }
}