using UnityEngine;
using UnityEngine.InputSystem;

public class OptionMenuButtons : MonoBehaviour
{
    #region Variables
    [Header("Linked Variables")]
    public GameObject[] uiInterfaces;
    public GameObject[] cameras;
    #endregion

    /// <summary>
    /// This function toggles the UI to the level select menu
    /// </summary>
    public void ToggleLevelSelect()
    {
        if (uiInterfaces[1].name == "Level Select Menu")
        {
            uiInterfaces[1].SetActive(true);
            uiInterfaces[0].SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Iterface array has incorrect index positions");
        }
    }

    /// <summary>
    /// This function toggles the UI to the settings menu
    /// </summary>
    public void ToggleSettings()
    {
        if (uiInterfaces[2].name == "Settings Menu")
        {
            uiInterfaces[2].SetActive(true);
            uiInterfaces[0].SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Iterface array has incorrect index positions");
        }
    }

    /// <summary>
    /// This function toggles the UI to the credits screen
    /// </summary>
    public void ToggleCredits()
    {
        if (uiInterfaces[3].name == "Credits Menu")
        {
            uiInterfaces[3].SetActive(true);
            uiInterfaces[0].SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Iterface array has incorrect index positions");
        }
    }

    /// <summary>
    /// This function toggles the UI to the quit screen
    /// </summary>
    public void ToggleQuit()
    {
        if (uiInterfaces[4].name == "Quit Menu")
        {
            uiInterfaces[4].SetActive(true);
            uiInterfaces[0].SetActive(false);
        }
        else
        {
            Debug.LogWarning("UI Iterface array has incorrect index positions");
        }
    }

    /// <summary>
    /// This function toggles the UI to the option screen when the escape button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void EscapeKey(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (cameras[0].name == "Main Menu Camera")
            {
                if (!cameras[0].activeInHierarchy)
                {
                    cameras[0].SetActive(true);
                    cameras[1].SetActive(false);
                }
            }
            else
            {
                Debug.LogWarning("Camera array has incorrect index positions");
            }

            foreach (GameObject uiElement in uiInterfaces)
            {
                if (uiElement.activeInHierarchy)
                {
                    uiElement.SetActive(false);
                }
            }

            uiInterfaces[0].SetActive(true);
        }
    }
}
