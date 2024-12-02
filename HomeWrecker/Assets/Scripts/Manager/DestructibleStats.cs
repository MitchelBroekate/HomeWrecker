using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleStats : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    [SerializeField] int health;
    [SerializeField] int scoreValue;

    [Header("Linked Variables")]
    public bool canDestroy = false;
    ScoreManager scoreManager;
    #endregion
    
    void Start()
    {
        scoreManager = GameObject.Find("Script Manager").GetComponent<ScoreManager>();
    }

    public void DoDamage(int damageAmount)
    {
        if(health <= 1)
        {
            canDestroy = true;
            AddScore();

        }
        else
        {
            health -= damageAmount;
        }
    }

    void AddScore()
    {
        scoreManager.updateScore(scoreValue);
    }
}