using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 75f; // default for Level 1
    public TextMeshProUGUI timerText;
    public GameObject checkpoint;
    public string nextSceneName = "Level2";

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
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver"); 
    }

    void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName); 
    }
}