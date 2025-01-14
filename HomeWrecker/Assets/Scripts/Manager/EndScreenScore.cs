using UnityEngine;
using TMPro;

public class EndScreenScore : MonoBehaviour
{
    [SerializeField] int currentScene;
    [SerializeField] ScoreManager scoreManager;
    
    int lastHighscore = 0;
    string lastTimeScore = "00:00:00";
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
                lastTimeScore = PlayerPrefs.GetString("TimeScoreMarktMedia");
                break;

            case 2:
                // lastHighscore = PlayerPrefs.GetInt("HighscoreFutureGame");
                // lastTimeScore = PlayerPrefs.GetString("TimeScoreFutureGame");
                Debug.Log("Level W.I.P");
                break;

            default:
                Debug.LogWarning("Scene int out of bounds (EndScreenScore/GetHighscore/Switch)");
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

        switch (currentScene)
        {
            case 0:
                if(currentScore > PlayerPrefs.GetInt("HighscoreTutorial"))
                {
                    textFields[4].text = currentScore.ToString();
                    PlayerPrefs.SetInt("HighscoreTutorial", currentScore);
                }
                break;

            case 1:
                if(currentScore > PlayerPrefs.GetInt("HighscoreMarktMedia"))
                {
                    textFields[4].text = currentScore.ToString();
                    PlayerPrefs.SetInt("HighscoreMarktMedia", currentScore);
                }
                break;

            case 2:
                if(currentScore > PlayerPrefs.GetInt("HighscoreFutureGame"))
                {
                    textFields[4].text = currentScore.ToString();
                    PlayerPrefs.SetInt("HighscoreFutureGame", currentScore);
                }
                break;

            default:
                Debug.LogWarning("Scene int out of bounds (EndScreenScore/GetCurrentScore/Switch)");
                break;
        }
    }

    public void GetTimeScore(float time)
    {
        switch(currentScene)
        {
            case 0:
                time = 300 - time;
                if(time < PlayerPrefs.GetFloat("TimeScoreFloatTutorial"))
                {
                    int minutesTut = Mathf.FloorToInt(time / 60f);
                    int secondsTut = Mathf.FloorToInt(time % 60f);
                    int millisecondsTut = Mathf.FloorToInt(time % 1 * 100);

                    textFields[5].text = $"{minutesTut:00}:{secondsTut:00}:{millisecondsTut:00}";
                    currentTimeScore = $"{minutesTut:00}:{secondsTut:00}:{millisecondsTut:00}";
                    
                }
                else
                {
                    int minutesTut = Mathf.FloorToInt(time / 60f);
                    int secondsTut = Mathf.FloorToInt(time % 60f);
                    int millisecondsTut = Mathf.FloorToInt(time % 1 * 100);

                    currentTimeScore = $"{minutesTut:00}:{secondsTut:00}:{millisecondsTut:00}";
                }
                break;

            case 1:
                time = 180 - time;
                if(time < PlayerPrefs.GetFloat("TimeScoreFloatMarktMedia"))
                {
                    int minutesMM = Mathf.FloorToInt(time / 60f);
                    int secondsMM = Mathf.FloorToInt(time % 60f);
                    int millisecondsMM = Mathf.FloorToInt(time % 1 * 100);

                    textFields[5].text = $"{minutesMM:00}:{secondsMM:00}:{millisecondsMM:00}";
                    currentTimeScore = $"{minutesMM:00}:{secondsMM:00}:{millisecondsMM:00}";
                }
                else
                {
                    int minutesMM = Mathf.FloorToInt(time / 60f);
                    int secondsMM = Mathf.FloorToInt(time % 60f);
                    int millisecondsMM = Mathf.FloorToInt(time % 1 * 100);

                    currentTimeScore = $"{minutesMM:00}:{secondsMM:00}:{millisecondsMM:00}";
                }
                break;
                
            case 2:
                // time = 600 - time;
                // if(time < PlayerPrefs.GetFloat("TimeScoreFloatFutureGame"))
                // {
                //     int minutesFG = Mathf.FloorToInt(time / 60f);
                //     int secondsFG = Mathf.FloorToInt(time % 60f);
                //     int millisecondsFG = Mathf.FloorToInt(time % 1 * 100);

                //     textFields[5].text = $"{minutesFG:00}:{secondsFG:00}:{millisecondsFG:00}";
                //     currentTimeScore = $"{minutesFG:00}:{secondsFG:00}:{millisecondsFG:00}";
                // }
                // else
                // {
                //     int minutesFG = Mathf.FloorToInt(time / 60f);
                //     int secondsFG = Mathf.FloorToInt(time % 60f);
                //     int millisecondsFG = Mathf.FloorToInt(time % 1 * 100);

                //     currentTimeScore = $"{minutesFG:00}:{secondsFG:00}:{millisecondsFG:00}";
                // }
                Debug.Log("Level W.I.P");
                break;
            default:
                Debug.LogWarning("Scene int out of bounds (EndScreenScore/GetTimeScore/Switch)");
                break;
        }


    }   

    //current score + time score linking at the end of the level
}
