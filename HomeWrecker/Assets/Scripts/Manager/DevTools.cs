using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DevTools : MonoBehaviour
{
    [SerializeField] int scoreAdd;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] StandSpawner standSpawner;
    [Tooltip("In seconds")]
    [SerializeField] int timeMin;
    [SerializeField] Timer timer;
    [SerializeField] Transform standParent;

    bool waitSkip;

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

    public void RemovePlayerPrefs(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void RespawnStands(InputAction.CallbackContext context)
    {

        if(context.performed)
        {
            if(!waitSkip)
            {
                if (standParent.childCount > 0)
                {
                    for(int i = standParent.childCount -1; i >= 0; i--)
                    {
                        Destroy(standParent.GetChild(i).gameObject);
                    }

                    standSpawner.SpawnStandsExternal();
                }

                StartCoroutine(RespawnCooldown());
            }
        }
    }

    IEnumerator RespawnCooldown()
    {
        waitSkip = true;
        yield return new WaitForSeconds(1);
        waitSkip = false;
    }
}
