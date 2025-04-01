using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("Checkpoint destroyed!");
        //Timer will be notified here
        TimerManager timer = FindObjectOfType<TimerManager>();
            if (timer != null)
            {
                timer.NotifyCheckpointDestroyed();
            } else {
            SceneManager.LoadScene("GameOver");
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the checkpoint box — GAME OVER!");

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
}