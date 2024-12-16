using UnityEngine;
using TMPro;

public class EndScreenScore : MonoBehaviour
{
    [SerializeField] int currentScene;
    [SerializeField] ScoreManager scoreManager;
    
    int lastHighscore;
    string lastTimeScore;
    int currentScore;
    string currentTimeScore;

    [SerializeField] TMP_Text[] textFields;

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

    public void ShowScores()
    {
        textFields[0].text = lastHighscore.ToString();
        textFields[1].text = currentScore.ToString();

        textFields[2].text = lastTimeScore;
        textFields[3].text = currentTimeScore;
    }

    public void GetCurrentScore()
    {
        currentScore = scoreManager.GetScore;
    }

    public void GetCurrentTimeScore(string time)
    {
        currentTimeScore = time;
    }   

    //current score + time score linking at the end of the level
}
