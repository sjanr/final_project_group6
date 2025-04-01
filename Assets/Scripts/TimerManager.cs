using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60f; // default for Level 1
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
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
        SceneManager.LoadScene("GameOver"); // make sure this is added to build settings
    }

    void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName); // set this in the Inspector per level
    }
}