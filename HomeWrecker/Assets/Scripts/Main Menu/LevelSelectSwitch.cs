using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class LevelSelectSwitch : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    [SerializeField] int currentSelectedLevel = 0;
    [SerializeField] float roomCameraMoveSpeed = 10;

    [Header("Linked Variables")]
    [SerializeField] Transform[] roomCameraMovePosition;
    [SerializeField] Transform roomCameraTransform;
    [SerializeField] TMP_Text roomName;
    [SerializeField] GameObject levelSelectObject;
    [SerializeField] ScoreManager scoreManager;
    #endregion

    /// <summary>
    /// This function updates the switch to check if the camera should move
    /// </summary>
    void Update()
    {
        if (roomCameraMovePosition != null)
        {
            RoomCamPosChange();
        }
        else
        {
            Debug.LogWarning("roomCameraMovePosition array empty!!!");
        }
    }

    /// <summary>
    /// This function allows the scene to switch to the current selected level when a button is pressed
    /// </summary>
    public void PlayScene()
    {
        switch (currentSelectedLevel)
        {
            case 0:
                SceneManager.LoadScene("Tutorial Level", LoadSceneMode.Single);
                break;

            case 1:
                SceneManager.LoadScene("MarktMedia", LoadSceneMode.Single);
                break;

            case 2:
                //SceneManager.LoadScene("Future Game", LoadSceneMode.Single);
                Debug.Log("Level W.I.P");
                break;
            
            default:
                Debug.LogWarning("No Int Value?!?! Play Scene Switch");
                break;
        }
    }

    /// <summary>
    /// This function goes to the next selected level when called
    /// </summary>
    public void ButtonNext()
    {
        if (currentSelectedLevel != 2)
        {
            currentSelectedLevel++;
        }
        else
        {
            currentSelectedLevel = 0;
        }

        scoreManager.SetHighscoreText(currentSelectedLevel);
        scoreManager.SetHighscoreTimeText(currentSelectedLevel);
    }

    /// <summary>
    /// This function goes to the next selected level when the "D" key is pressed
    /// </summary>
    public void DKeyNext(InputAction.CallbackContext context)
    {
        if(context.performed && levelSelectObject.activeInHierarchy)
        {    
            if (currentSelectedLevel != 2)
            {
                currentSelectedLevel++;
            }
            else
            {
                currentSelectedLevel = 0;
            }

            scoreManager.SetHighscoreText(currentSelectedLevel);
            scoreManager.SetHighscoreTimeText(currentSelectedLevel);
        }
    }

    /// <summary>
    /// This function goes to the previous selected level when called
    /// </summary>
    public void ButtonPrevious()
    {
        if (currentSelectedLevel != 0)
        {
            currentSelectedLevel--;
        }
        else
        {
            currentSelectedLevel = 2;
        }

        scoreManager.SetHighscoreText(currentSelectedLevel);
        scoreManager.SetHighscoreTimeText(currentSelectedLevel);
    }

    /// <summary>
    /// This function goes to the previous selected level when the "A" key is pressed
    /// </summary>
    public void AKeyPrevious(InputAction.CallbackContext context)
    {
        if(context.performed && levelSelectObject.activeInHierarchy)
        {    
            if (currentSelectedLevel != 0)
            {
                currentSelectedLevel--;
            }
            else
            {
                currentSelectedLevel = 2;
            }

            scoreManager.SetHighscoreText(currentSelectedLevel);
            scoreManager.SetHighscoreTimeText(currentSelectedLevel);
        }
    }

    /// <summary>
    /// This function checks which position the camera needs to move to and moves the camera over time
    /// </summary>
    void RoomCamPosChange()
    {
        float moveSpeed = roomCameraMoveSpeed * Time.deltaTime;

        if (roomCameraMoveSpeed <= 0) roomCameraMoveSpeed = 10;

        switch (currentSelectedLevel)
        {
            case 0:
                if (roomCameraMovePosition[currentSelectedLevel].name == "Room 1 Cam Pos")
                {
                    roomCameraTransform.position = Vector3.MoveTowards(roomCameraTransform.position, roomCameraMovePosition[currentSelectedLevel].position, moveSpeed);
                    roomName.text = "Tutorial";
                }
                else
                {
                    Debug.LogWarning("Camera Move Position array has incorrect index positions");
                }
                break;

            case 1:
                if (roomCameraMovePosition[currentSelectedLevel].name == "Room 2 Cam Pos")
                {
                    roomCameraTransform.position = Vector3.MoveTowards(roomCameraTransform.position, roomCameraMovePosition[currentSelectedLevel].position, moveSpeed);
                    roomName.text = "Markt Media";
                }
                else
                {
                    Debug.LogWarning("Camera Move Position array has incorrect index positions");
                }
                break;

            case 2:
                if (roomCameraMovePosition[currentSelectedLevel].name == "Room 3 Cam Pos")
                {
                    roomCameraTransform.position = Vector3.MoveTowards(roomCameraTransform.position, roomCameraMovePosition[currentSelectedLevel].position, moveSpeed);
                    roomName.text = "Coming Soon";
                }
                else
                {
                    Debug.LogWarning("Camera Move Position array has incorrect index positions");
                }
                break;

            default:
                Debug.LogWarning("No Int Value?!?! Level Selector Switch");
                break;
        }
    }
}
