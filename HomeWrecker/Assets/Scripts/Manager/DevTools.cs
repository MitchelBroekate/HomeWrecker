using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DevTools : MonoBehaviour
{
    [SerializeField] int scoreAdd;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int timeMin;
    [SerializeField] Timer timer;

    public void AddScore(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            scoreManager.AddScore(scoreAdd);
        }
    }

    public void MinTime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            timer.DevDecreaseTime(timeMin);
        }
    }
}
