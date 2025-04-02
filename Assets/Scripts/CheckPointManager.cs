using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    //removed after talking to TA - ended up destroying player as well so caused bugs

    /* private void OnDestroy()
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
    }*/

    //check point collision based on trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))// if collision with player send to game over scene
        {
            SceneManager.LoadScene("GameOver");
        }
        if (other.CompareTag("bullet"))//if collision with bullet
        {
            Debug.Log("bullet touched the checkpoint box — next level");
            //GameSession.lastLevel = SceneManager.GetActiveScene().name;

            // find current scene and move to next scene accordingly
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