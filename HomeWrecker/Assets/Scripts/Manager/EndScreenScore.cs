using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenScore : MonoBehaviour
{
    //last achieved highscore + time score linking in the start
    [SerializeField] int currentScene;
    [SerializeField] ScoreManager scoreManager;
    int lastHighscore;
    string lastTimeScore;

    int currentScore;
    string currentTimeScore;

    void Start ()
    {
        GetHighscore();
    }

    void GetHighscore()
    {
        switch (currentScene)
        {
            case 0:
                lastHighscore = PlayerPrefs.GetInt("HighscoreTutorial");
                lastTimeScore = PlayerPrefs.GetString("TimeScoreTutorial");
                break;

            case 1:
                lastHighscore = PlayerPrefs.GetInt("HighscoreMarktMedia");
                lastTimeScore = PlayerPrefs.GetString("HighscoreMarktMedia");
                break;

            case 2:
                lastHighscore = PlayerPrefs.GetInt("TimeScoreFutureGame");
                lastTimeScore = PlayerPrefs.GetString("TimeScoreFutureGame");
                break;

            default:
                Debug.LogWarning("Scene int out of bounds (EndScreenScore/GetScore/Switch)");
                break;
        }
    }

    void GetCurrentScore()
    {
        currentScore = scoreManager.GetScore;
    }   

    //current score + time score linking at the end of the level
}
