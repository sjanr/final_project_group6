using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("Loaded Game Over Screen");
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;

        Debug.Log("Restarting from: " + GameSession.lastLevel);
        SceneManager.LoadScene(GameSession.lastLevel);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}