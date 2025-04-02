using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOffWorldDetection : MonoBehaviour
{
    //GameOver for when the player falls out of the world
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player fell out of world");
            //Destroy(collision.gameObject);

            GameSession.lastLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOver");
        }
    }
}
