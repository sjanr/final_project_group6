using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 75f; // default for Level 1
    public TextMeshProUGUI timerText;
    public GameObject checkpoint;
    // private string nextSceneName = "Level2v2Audio";

    private bool timerIsRunning = true;
    private bool checkpointDestroyed = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
{
    if (!timerIsRunning || checkpointDestroyed) return;

    if (timeRemaining > 0)
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0f)
        {
            timeRemaining = 0f;
        }

        UpdateTimerDisplay();
    }

    if (timeRemaining <= 0f)
    {
        GameOver();
    }
}

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = $"Time Left: {minutes:00}:{seconds:00}";
    }

    public void NotifyCheckpointDestroyed()
    {
        checkpointDestroyed = true;
        timerIsRunning = false;
        LoadNextLevel();
    }

    void GameOver()
    {
        timerIsRunning = false;
        StartCoroutine(PlayGameOverAndLoad());
    }

    IEnumerator PlayGameOverAndLoad()
    {
        AudioManager.instance.playSound(AudioManager.instance.gameOverClip);

        float delay = AudioManager.instance.gameOverClip != null
            ? AudioManager.instance.gameOverClip.length
            : 1f; // fallback if clip is null

        yield return new WaitForSeconds(delay);

        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }

    void LoadNextLevel()
    {
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