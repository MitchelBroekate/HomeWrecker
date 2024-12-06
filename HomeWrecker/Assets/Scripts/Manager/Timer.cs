using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    [Tooltip("Time in seconds")]
    [SerializeField] float countdownTime = 60f;

    [Header("Linked Variables")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] ScoreManager scoreManager;
    float currentTime;

    //Used only inside the script
    bool _isCountingDown = false;
    #endregion

    /// <summary>
    /// This function sets the time of the timer and starts the countdown
    /// </summary>
    void Start()
    {
        currentTime = countdownTime;

        StartCountdown();
    }

    /// <summary>
    /// This function counts down until it reaches 0 and uploads the score or if the max score is reached saves the score and time
    /// </summary>
    void Update()
    {
        if (_isCountingDown && currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            currentTime = Mathf.Max(currentTime, 0);

            UpdateTimerText();

            if (currentTime <= 0)
            {
                StopCountdown();

                scoreManager.UpdateHighscore();
            }

            if(scoreManager.GetScore >= 20000)
            {
                StopCountdown();
                scoreManager.UpdateHighscore();
                scoreManager.UpdateHighscoreTimerText(currentTime);
            }
        }
    }

    /// <summary>
    /// This funtion sets the countdown states to start the countdown
    /// </summary>
    void StartCountdown()
    {
        currentTime = countdownTime;
        _isCountingDown = true;
        UpdateTimerText();
    }

    /// <summary>
    /// This function stops the countdown
    /// </summary>
    void StopCountdown()
    {
        _isCountingDown = false;
    }

    /// <summary>
    /// This function formats the timer for the UI
    /// </summary>
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt(currentTime % 1 * 100);

        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }
}
