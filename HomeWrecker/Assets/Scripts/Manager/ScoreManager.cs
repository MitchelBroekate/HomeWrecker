using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    public int currentScene;
    
    [Header("Linked Variables")]
    [SerializeField] int _score = 0;
    [SerializeField] float timeScoreCompare;
    public TMP_Text score;
    public TMP_Text highscore;
    [Tooltip("This variable is only linked in the main menu")]
    public TMP_Text timeScore;

    [SerializeField] GameObject unlockPopUp;
    [SerializeField] TMP_Text unlockPopupText;
    bool popUp1 = true;
    string popUp1TXT = " KEY(2)";
    bool popUp2 = true;
    string popUp2TXT = " KEY(3)";
    bool popUp3 = true;
    string popUp3TXT = " KEY(4)";
    bool popUp4 = true;
    string popUp4TXT = " KEY(5)";

    [SerializeField] TMP_Text addScoreTXT;
    int _scoreToCreate;
    int addScore;
    bool activeScoreAdd;
    float addScoreWaitTime;
    #endregion

    /// <summary>
    /// This function checks for playerprefs and sets the highscore  for the first level
    /// </summary>
    void Start()
    {
        LoadScore();



        switch(currentScene)
        {
            case 0:
                if(!PlayerPrefs.HasKey("TimeScoreFloatTutorial"))
                {
                    PlayerPrefs.SetFloat("TimeScoreFloatTutorial", 300);
                }
                else
                {
                    timeScoreCompare = PlayerPrefs.GetFloat("TimeScoreFloatTutorial");
                }
                break;

            case 1:
                if(!PlayerPrefs.HasKey("TimeScoreFloatMarktMedia"))
                {
                    PlayerPrefs.SetFloat("TimeScoreFloatMarktMedia", 180);
                }
                else
                {
                    timeScoreCompare = PlayerPrefs.GetFloat("TimeScoreFloatMarktMedia");
                }
                break;

            case 2: 
                 if(!PlayerPrefs.HasKey("TimeScoreFloatFutureGame"))
                 {
                     PlayerPrefs.SetFloat("TimeScoreFloatFutureGame", 600);
                 }
                 else
                 {
                     timeScoreCompare = PlayerPrefs.GetFloat("TimeScoreFloatFutureGame");
                 }
                Debug.Log("Level W.I.P");
                break;

            default:
                Debug.LogWarning("Scene int out of bounds (ScoreManager/Start/Switch)");
                break;
        }

        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            highscore.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();
            timeScore.text = PlayerPrefs.GetString("TimeScoreTutorial");
        }
    }

    void Update()
    {
        if(_score >= 2500)
        {
            if(popUp1)
            {
                popUp1 = false;
                StopAllCoroutines();
                unlockPopupText.text = "You unlocked a new weapon" +  popUp1TXT;
                StartCoroutine(PopUpUnlockWeapon());
            }
        }
        if(_score >= 7500)
        {
            if(popUp2)
            {
                popUp2 = false;
                StopAllCoroutines();
                unlockPopupText.text = "You unlocked a new weapon" +  popUp2TXT;
                StartCoroutine(PopUpUnlockWeapon());
            }
        }
        if(_score >= 17500)
        {
            if(popUp3)
            {
                popUp3 = false;
                StopAllCoroutines();
                unlockPopupText.text = "You unlocked a new weapon" +  popUp3TXT;
                StartCoroutine(PopUpUnlockWeapon());
            }
        }
        if(_score >= 20000)
        {
            if(popUp4)
            {
                popUp4 = false;
                StopAllCoroutines();
                unlockPopupText.text = "You unlocked a new weapon" +  popUp4TXT;
                StartCoroutine(PopUpUnlockWeapon());
            }
        }

        if(currentScene == 0)
        {
            if(_score > 40000)
            {
                _score = 40000;
            }
        }
        else
        {
            if(_score > 60000)
            {
                _score = 60000;
            }
        }

        if(addScoreTXT != null)
        {
            if(addScoreWaitTime > 0)
            {
                addScoreWaitTime -= Time.deltaTime;
                activeScoreAdd = true;

                addScoreTXT.text = "+" + addScore.ToString();
            }
            else
            {
                activeScoreAdd = false;
                addScoreTXT.text = "";
            }
        }

        
        if(addScoreWaitTime > 2)
        {
            addScoreWaitTime = 2;
        }

    }

    /// <summary>
    /// This function adds and stores the score you gain from object to an internal int
    /// </summary>
    /// <param name="scoreValue"></param>
    public void AddScore(int scoreValue)
    {
        _score += scoreValue;

        if(activeScoreAdd && scoreValue > 0)
        {
            addScore += scoreValue;
            addScoreWaitTime += 1;
        }
        else if(!activeScoreAdd && scoreValue > 0)
        {
            addScore = scoreValue;
            addScoreWaitTime += 1;
        }

        
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

        if(!PlayerPrefs.HasKey("HighscoreMarktMedia"))
        {
            _scoreToCreate = 1;
            CreateStartScore();
        }

         if(!PlayerPrefs.HasKey("HighscoreFutureGame"))
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
                PlayerPrefs.SetString("TimeScoreTutorial", "00:00:00");
                break;

            case 1:
                PlayerPrefs.SetInt("HighscoreMarktMedia", 0);
                PlayerPrefs.SetString("TimeScoreMarktMedia", "00:00:00");
                break;

            case 2:
                PlayerPrefs.SetInt("HighscoreFutureGame", 0);
                PlayerPrefs.SetString("TimeScoreFutureGame", "00:00:00");
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
    /// <param name="highscoreScene"></param>
    public void SetHighscoreText(int highscoreScene)
    {
        switch(highscoreScene)
        {
            case 0:
                highscore.text = PlayerPrefs.GetInt("HighscoreTutorial").ToString();
                break;

            case 1:
                highscore.text = PlayerPrefs.GetInt("HighscoreMarktMedia").ToString();
                break;

            case 2:
                highscore.text = PlayerPrefs.GetInt("HighscoreFutureGame").ToString();
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
                    PlayerPrefs.SetInt("HighscoreFutureGame", _score);
                }
                Debug.Log("How did you manage to do this?!?");
                break;
            
            default:
                Debug.LogWarning("No Int Value?!?! Update Highscore Switch");
                break;
        }
    }

    /// <summary>
    /// This function formats the timer score for the UI
    /// </summary>
    /// <param name="highscoreTime"></param>
    public void UpdateHighscoreTimer(float highscoreTime)
    {
        switch(currentScene)
        {
            case 0:
                highscoreTime = 300 - highscoreTime;

                if(highscoreTime < timeScoreCompare)
                {
                    int minutesTut = Mathf.FloorToInt(highscoreTime / 60f);
                    int secondsTut = Mathf.FloorToInt(highscoreTime % 60f);
                    int millisecondsTut = Mathf.FloorToInt(highscoreTime % 1 * 100);

                    PlayerPrefs.SetString("TimeScoreTutorial", $"{minutesTut:00}:{secondsTut:00}:{millisecondsTut:00}");
                    PlayerPrefs.SetFloat("TimeScoreFloatTutorial", highscoreTime);
                }
                break;

            case 1:
                highscoreTime = 180 - highscoreTime;

                if(highscoreTime < timeScoreCompare)
                {
                    int minutesMM = Mathf.FloorToInt(highscoreTime / 60f);
                    int secondsMM = Mathf.FloorToInt(highscoreTime % 60f);
                    int millisecondsMM = Mathf.FloorToInt(highscoreTime % 1 * 100);

                    PlayerPrefs.SetString("TimeScoreMarktMedia", $"{minutesMM:00}:{secondsMM:00}:{millisecondsMM:00}");
                    PlayerPrefs.SetFloat("TimeScoreFloatMarktMedia", highscoreTime);
                }
                break;
        
            case 2:
                highscoreTime = 0 - highscoreTime;

                if(highscoreTime < timeScoreCompare)
                {
                    int minutesFG = Mathf.FloorToInt(highscoreTime / 60f);
                    int secondsFG = Mathf.FloorToInt(highscoreTime % 60f);
                    int millisecondsFG = Mathf.FloorToInt(highscoreTime % 1 * 100);

                    PlayerPrefs.SetString("TimeScoreFutureGame", $"{minutesFG:00}:{secondsFG:00}:{millisecondsFG:00}");
                    PlayerPrefs.SetFloat("TimeScoreFloatFutureGame", highscoreTime);
                }
                Debug.Log("How did you manage to do this?!?");
                break;
            
            default:
                Debug.LogWarning("No Int Value?!?! Update HighscoreTimer Switch");
                break;
        }
    }

    public void SetHighscoreTimeText(int timeScoreScene)
    {
        switch(timeScoreScene)
        {
            case 0:
                timeScore.text = PlayerPrefs.GetString("TimeScoreTutorial");
                break;

            case 1:
                timeScore.text = PlayerPrefs.GetString("TimeScoreMarktMedia");
                break;

            case 2:
                timeScore.text = PlayerPrefs.GetString("TimeScoreFutureGame");
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

    IEnumerator PopUpUnlockWeapon()
    {
        unlockPopUp.SetActive(true);
        yield return new WaitForSeconds(3);
        unlockPopUp.SetActive(false);
    }
}
