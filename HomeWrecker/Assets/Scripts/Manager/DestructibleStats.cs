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

    /// <summary>
    /// This function assigns the ScoreManager script to the variable
    /// </summary>
    void Start()
    {
        scoreManager = GameObject.Find("Script Manager").GetComponent<ScoreManager>();
    }

    /// <summary>
    /// This function allows the player to deal damage to the local object and add give the death conditions of the object
    /// </summary>
    /// <param name="damageAmount"></param>
    public void DoDamage(int damageAmount)
    {
        float shakeDuration = 0.35f;
        float shakeStrength = 0.025f;
        StartCoroutine(Camera.main.GetComponent<TamaraCameraShake>().Shake(shakeDuration, shakeStrength));
        health -= damageAmount;
        if (health <= 1)
        {
            canDestroy = true;
            AddScore();
        }

    }

    /// <summary>
    /// This function adds the assigned score of the local object to the ScoreManager
    /// </summary>
    void AddScore()
    {
        scoreManager.AddScore(scoreValue);
    }

    public void SetHealth(int healthAdd)
    {
        health = healthAdd;
    }
    public void SetScore(int scoreAdd)
    {
        scoreValue = scoreAdd;
    }

    public void SetDestroyable()
    {
        canDestroy = true;
    }
}