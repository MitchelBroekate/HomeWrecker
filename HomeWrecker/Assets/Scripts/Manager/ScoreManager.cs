using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score = 0;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int _scoreToCreate;

    void Start()
    {
        LoadScore();

        highscoreText.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();
    }

    public void AddScore(int scoreValue)
    {
        _score += scoreValue;
    }

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
        }
    }

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
        }
    }

    public void UpdateHighscore(int scoreToUpdate)
    {
        switch(scoreToUpdate)
        {
            case 0:
                PlayerPrefs.SetInt("HighscoreTutorial", _score);
                break;

            case 1:
                PlayerPrefs.SetInt("HighscoreMarktMedia", _score);
                break;
        
            case 2:
                //PlayerPrefs.SetInt("HighscoreFutureGame", _score);
                Debug.Log("How did you manage to do this?!?");
                break;
        }
    }
}
