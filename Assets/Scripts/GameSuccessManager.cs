using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSuccessManager : MonoBehaviour
{
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        Debug.Log("Restarting from: " + GameSession.lastLevel);
        SceneManager.LoadScene("Level1v1Audio"); // always go back to Level 1
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