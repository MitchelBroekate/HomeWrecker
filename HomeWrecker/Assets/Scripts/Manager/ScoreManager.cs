using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Variables
    [Header("Linked Variables")]
    [SerializeField] int _score = 0;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int _scoreToCreate;
    #endregion

    /// <summary>
    /// This function checks for playerprefs and sets the highscore text for the first level
    /// </summary>
    void Start()
    {
        LoadScore();

        highscoreText.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();
    }

    /// <summary>
    /// This function adds and stores the score you gain from object to an internal int
    /// </summary>
    /// <param name="scoreValue"></param>
    public void AddScore(int scoreValue)
    {
        _score += scoreValue;
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
                break;

            case 1:
                PlayerPrefs.SetInt("HighscoreMarktMedia", 0);
                break;

            case 2:
                //PlayerPrefs.SetInt("HighscoreFutureGame", 0);
                Debug.Log("Level W.I.P");
                break;

            default:
                Debug.LogWarning("No Int Value?!?! Create Base Highscore Switch");
                break;
        }
    }

    /// <summary>
    /// This function sets the highscore text for the selected level to the current highscore
    /// </summary>
    /// <param name="highscoreValue"></param>
    public void SetHighscoreText(int highscoreValue)
    {
        switch(highscoreValue)
        {
            case 0:
                highscoreText.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();
                break;

            case 1:
                highscoreText.text = PlayerPrefs.GetInt("HighscoreMarktMedia").ToString();
                break;

            case 2:
                //highscoreText.text = PlayerPrefs.GetInt("HighscoreFutureGame").ToString();
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
    public void UpdateHighscore(int scoreToUpdate)
    {
        switch(scoreToUpdate)
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
                    PlayerPrefs.SetInt("HighscoreFutureGame", _score);
                }
                Debug.Log("How did you manage to do this?!?");
                break;
            
            default:
                Debug.LogWarning("No Int Value?!?! Update Highscore Switch");
                break;
        }
    }
}
