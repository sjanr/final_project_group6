using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("Checkpoint destroyed!");
        //Timer will be notified here
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the checkpoint box — GAME OVER!");

            SceneManager.LoadScene("GameOver"); 
        }
    }
}