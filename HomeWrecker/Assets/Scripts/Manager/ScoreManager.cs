using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    public int currentScene;
    
    [Header("Linked Variables")]
    [SerializeField] int _score = 0;
    public TMP_Text score;
    public TMP_Text highscore;
    public TMP_Text timeScore;

    int _scoreToCreate;
    #endregion

    /// <summary>
    /// This function checks for playerprefs and sets the highscore  for the first level
    /// </summary>
    void Start()
    {
        LoadScore();

        highscore.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();

        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            timeScore.text = PlayerPrefs.GetString("TimeScoreTutorial");
        }
    }

    /// <summary>
    /// This function adds and stores the score you gain from object to an internal int
    /// </summary>
    /// <param name="scoreValue"></param>
    public void AddScore(int scoreValue)
    {
        _score += scoreValue;

        score.text = _score.ToString();
    }

    /// <summary>
    /// This function checks if there already is a playerpref made for the scores. if not, a base score will be made
    /// </summary>
    void LoadScore()
    {
        if(!PlayerPrefs.HasKey("HighscoreTutorial"))
        {
            _scoreToCreate = 0;
            CreateStartScore();
        }

        if(PlayerPrefs.HasKey("HighscoreMarktMedia"))
        {
            _scoreToCreate = 1;
            CreateStartScore();
        }

        if(PlayerPrefs.HasKey("HighscoreFutureGame"))
        {
            _scoreToCreate = 2;
            CreateStartScore();
        }
    }

    /// <summary>
    /// This function creates a base score playerpref for each level
    /// </summary>
    void CreateStartScore()
    {
        switch(_scoreToCreate)
        {
            case 0:
                PlayerPrefs.SetInt("HighscoreTutorial", 0);
                PlayerPrefs.SetString("TimeScoreTutorial", "-----");
                break;

            case 1:
                PlayerPrefs.SetInt("HighscoreMarktMedia", 0);
                PlayerPrefs.SetString("TimeScoreMarktMedia", "-----");
                break;

            case 2:
                //PlayerPrefs.SetInt("HighscoreFutureGame", 0);
                //PlayerPrefs.SetString("TimeScoreFutureGame", "-----");
                Debug.Log("Level W.I.P");
                break;

            default:
                Debug.LogWarning("No Int Value?!?! Create Base Highscore Switch");
                break;
        }
    }

    /// <summary>
    /// This function sets the highscore  for the selected level to the current highscore
    /// </summary>
    /// <param name="highscoreValue"></param>
    public void SetHighscoreText(int highscoreValue)
    {
        switch(highscoreValue)
        {
            case 0:
                highscore.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();
                break;

            case 1:
                highscore.text = PlayerPrefs.GetInt("HighscoreMarktMedia").ToString();
                break;

            case 2:
                //highscore.text = PlayerPrefs.GetInt("HighscoreFutureGame").ToString();
                Debug.Log("Level W.I.P");
                break;

            default:
                Debug.LogWarning("No Int Value?!?! Highscore Switch");
                break;
        }
    }

    /// <summary>
    /// This function updates the highscore if the current score is higher
    /// </summary>
    /// <param name="scoreToUpdate"></param>
    public void UpdateHighscore()
    {

        switch(currentScene)
        {
            case 0:
                if(_score > PlayerPrefs.GetInt("HighscoreTutorial"))
                {    
                    PlayerPrefs.SetInt("HighscoreTutorial", _score);
                }
                break;

            case 1:
                if(_score > PlayerPrefs.GetInt("HighscoreMarktMedia"))
                {    
                    PlayerPrefs.SetInt("HighscoreMarktMedia", _score);
                }
                break;
        
            case 2:
                if(_score > PlayerPrefs.GetInt("HighscoreFutureGame"))
                {    
                    //PlayerPrefs.SetInt("HighscoreFutureGame", _score);
                }
                Debug.Log("How did you manage to do this?!?");
                break;
            
            default:
                Debug.LogWarning("No Int Value?!?! Update Highscore Switch");
                break;
        }
    }

    /// <summary>
    /// TTis function formats the timer score for the UI
    /// </summary>
    /// <param name="highscoreTime"></param>
    public void UpdateHighscoreTimer(float highscoreTime)
    {
        switch(currentScene)
        {
            case 0:
                highscoreTime = 600 - highscoreTime;

                int minutesTut = Mathf.FloorToInt(highscoreTime / 60f);
                int secondsTut = Mathf.FloorToInt(highscoreTime % 60f);
                int millisecondsTut = Mathf.FloorToInt(highscoreTime % 1 * 100);

                PlayerPrefs.SetString("TimeScoreTutorial", $"{minutesTut:00}:{secondsTut:00}:{millisecondsTut:00}");
                break;

            case 1:
                highscoreTime = 180 - highscoreTime;

                int minutesMM = Mathf.FloorToInt(highscoreTime / 60f);
                int secondsMM = Mathf.FloorToInt(highscoreTime % 60f);
                int millisecondsMM = Mathf.FloorToInt(highscoreTime % 1 * 100);

                PlayerPrefs.SetString("TimeScoreMarktMedia", $"{minutesMM:00}:{secondsMM:00}:{millisecondsMM:00}");
                break;
        
            case 2:
                // highscoreTime = 180 - highscoreTime;

                // int minutesFG = Mathf.FloorToInt(highscoreTime / 60f);
                // int secondsFG = Mathf.FloorToInt(highscoreTime % 60f);
                // int millisecondsFG = Mathf.FloorToInt(highscoreTime % 1 * 100);

                // PlayerPrefs.SetString("TimeScoreFutureGame", $"{minutesFG:00}:{secondsFG:00}:{millisecondsFG:00}");
                Debug.Log("How did you manage to do this?!?");
                break;
            
            default:
                Debug.LogWarning("No Int Value?!?! Update HighscoreTimer Switch");
                break;
        }
    }

    public void SetHighscoreTimeText(int timeScoreValue)
    {
        switch(timeScoreValue)
        {
            case 0:
                timeScore.text = PlayerPrefs.GetString("TimeScoreTutorial");
                break;

            case 1:
                timeScore.text = PlayerPrefs.GetString("TimeScoreMarktMedia");
                break;

            case 2:
                //timeScore.text = PlayerPrefs.GetString("TimeScoreFutureGame");
                Debug.Log("Level W.I.P");
                break;

            default:
                Debug.LogWarning("No Int Value?!?! Highscore Switch");
                break;
        }
    }

    /// <summary>
    /// This int returns the score variable
    /// </summary>
    public int GetScore
    {
        get{ return _score; }
    }
}
