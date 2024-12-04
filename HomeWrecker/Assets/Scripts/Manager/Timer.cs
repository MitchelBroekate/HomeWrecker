using UnityEngine;
using TMPro;
using UnityEditor.EditorTools;

public class Timer : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    [Tooltip("Time in seconds")]
    [SerializeField] float countdownTime = 60f;

    [Header("Linked Variables")]
    [SerializeField] TextMeshProUGUI timerText;

    //Used only inside the script
    float _currentTime;
    bool _isCountingDown = false;
    #endregion

    /// <summary>
    /// This function sets the time of the timer and starts the countdown
    /// </summary>
    void Start()
    {
        _currentTime = countdownTime;

        StartCountdown();
    }

    /// <summary>
    /// This function does the countdown until it reaches 0
    /// </summary>
    void Update()
    {
        if (_isCountingDown && _currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            _currentTime = Mathf.Max(_currentTime, 0);

            UpdateTimerText();

            if (_currentTime <= 0)
            {
                StopCountdown();
            }
        }
    }

    /// <summary>
    /// This funtion sets the countdown states to start the countdown
    /// </summary>
    void StartCountdown()
    {
        _currentTime = countdownTime;
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
        int minutes = Mathf.FloorToInt(_currentTime / 60f);
        int seconds = Mathf.FloorToInt(_currentTime % 60f);
        int milliseconds = Mathf.FloorToInt(_currentTime % 1 * 1000);

        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }
}
