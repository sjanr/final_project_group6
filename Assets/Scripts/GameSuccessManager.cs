using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSuccessManager : MonoBehaviour
{
    public float delayBeforeUI = 2f;
    public GameObject uiPanel; // assign this to the panel with your buttons

    private void Start()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false); // Hide the UI initially

        StartCoroutine(PlayVictoryAndShowUI());
    }

    IEnumerator PlayVictoryAndShowUI()
    {
        // Play success audio if available
        if (AudioManager.instance != null && AudioManager.instance.gameSuccessClip != null)
        {
            AudioManager.instance.playSound(AudioManager.instance.gameSuccessClip);
            yield return new WaitForSeconds(AudioManager.instance.gameSuccessClip.length);
        }
        else
        {
            yield return new WaitForSeconds(delayBeforeUI); 
        }

        if (uiPanel != null)
            uiPanel.SetActive(true); 
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        Debug.Log("Restarting from: " + GameSession.lastLevel);
        SceneManager.LoadScene("Level1v1Audio"); 
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