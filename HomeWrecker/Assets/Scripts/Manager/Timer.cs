using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    [Tooltip("Time in seconds")]
    [SerializeField] float countdownTime = 60f;

    [Header("Linked Variables")]
    [SerializeField] TMP_Text timerText;
    float currentTime;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PlayerController playerController;
    [SerializeField] EndScreenScore endScreenScore;
    [SerializeField] GameObject[] uiScreens;

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
            GameFinishScore();
            
            currentTime -= Time.deltaTime;

            currentTime = Mathf.Max(currentTime, 0);

            UpdateTimerText();
        }

        if (currentTime <= 0)
        {
            StopCountdown();
            
            currentTime = 0;
            UpdateTimerText();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            endScreenScore.GetTimeScore(currentTime);
            endScreenScore.GetCurrentScore();

            scoreManager.UpdateHighscore();
            scoreManager.UpdateHighscoreTimer(currentTime);

            playerController.LockPlayer(true);

            foreach (var uiScreenV in uiScreens)
            {
                if (uiScreenV.gameObject.activeSelf)
                {
                    uiScreenV.gameObject.SetActive(false);
                }
            }

            uiScreens[uiScreens.Length -1].SetActive(true);

            endScreenScore.ShowScores();
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
    public void StopCountdown()
    {
        _isCountingDown = false;
    }

    public void ResumeCountdown()
    {
        _isCountingDown = true;
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

    void GameFinishScore()
    {
        switch (scoreManager.currentScene)
        {
            case 0:
                if(scoreManager.GetScore >= 40000)
                {
                    StopCountdown();
                    scoreManager.UpdateHighscore();
                    scoreManager.UpdateHighscoreTimer(currentTime);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    endScreenScore.GetTimeScore(currentTime);
                    endScreenScore.GetCurrentScore();

                    playerController.LockPlayer(true);

                    foreach (var uiScreenV in uiScreens)
                    {
                        if (uiScreenV.gameObject.activeSelf)
                        {
                            uiScreenV.gameObject.SetActive(false);
                        }
                    }

                    uiScreens[uiScreens.Length -1].SetActive(true);

                    endScreenScore.ShowScores();
                }
            break;

            case 1:
                if(scoreManager.GetScore >= 20000)
                {
                    StopCountdown();
                    scoreManager.UpdateHighscore();
                    scoreManager.UpdateHighscoreTimer(currentTime);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    endScreenScore.GetTimeScore(currentTime);
                    endScreenScore.GetCurrentScore();

                    playerController.LockPlayer(true);

                    foreach (var uiScreenV in uiScreens)
                    {
                        if (uiScreenV.gameObject.activeSelf)
                        {
                            uiScreenV.gameObject.SetActive(false);
                        }
                    }

                    uiScreens[uiScreens.Length -1].SetActive(true);

                    endScreenScore.ShowScores();
                }
            break;

            case 2:
                if(scoreManager.GetScore >= 20000)
                {
                    StopCountdown();
                    scoreManager.UpdateHighscore();
                    scoreManager.UpdateHighscoreTimer(currentTime);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    endScreenScore.GetTimeScore(currentTime);
                    endScreenScore.GetCurrentScore();

                    playerController.LockPlayer(true);

                    foreach (var uiScreenV in uiScreens)
                    {
                        if (uiScreenV.gameObject.activeSelf)
                        {
                            uiScreenV.gameObject.SetActive(false);
                        }
                    }

                    uiScreens[uiScreens.Length -1].SetActive(true);

                    endScreenScore.ShowScores();
                }
            break;

            default:
                Debug.LogWarning("No Int Value?!?! SceneCheck Switch");
            break;
        }
    }

    public void DevDecreaseTime(int time)
    {
        currentTime -= time;
    }
}
