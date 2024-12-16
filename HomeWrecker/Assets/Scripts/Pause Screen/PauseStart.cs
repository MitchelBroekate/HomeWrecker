using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseStart : MonoBehaviour
{
    #region Variables
    [Header("Linked Variables")]
    bool isPaused = false;
    [SerializeField] CanvasGroup fadeCanvasBackground;
    [SerializeField] CanvasGroup fadeCanvasMenu;
    [SerializeField] GameObject pauseUI;
    [SerializeField] Animator animator;
    [SerializeField] Button buttonBack;
    [SerializeField] Button buttonResume;

    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject player;
    [SerializeField] GameObject hudCanvas;
    [SerializeField] GameObject endScreen;

    [SerializeField] Timer timer;

    Rigidbody _rb;
    #endregion

    void Start()
    {
        fadeCanvasBackground.alpha = 0f;
        fadeCanvasMenu.alpha = 1f;
        _rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isPaused)
        {
            UIShow();
        }
        else
        {
            UIHide();
        }
    }

    public void PauseSwitch(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(!endScreen.activeSelf) return;

            if (!isPaused)
            {
                StopAllCoroutines();

                isPaused = true;
                
                if(hudCanvas.activeInHierarchy)
                {
                    hudCanvas.SetActive(false);
                }

                if(!pauseUI.activeInHierarchy)
                {
                    pauseUI.SetActive(true);
                }

                animator.SetBool("Unpause", false);
                animator.SetBool("Pause", true);

                playerController.LockPlayer(true);
                timer.StopCountdown();
                
                _rb.velocity = Vector3.zero;
            }
            else
            {
                StopAllCoroutines();

                isPaused = false;

                animator.SetBool("Pause", false);
                animator.SetBool("Unpause", true);

                playerController.LockPlayer(false);
                timer.ResumeCountdown();

                StartCoroutine(UnpauseAnimationTime());
            }
        }
    }

    public void PauseMenuButtonBack()
    {
        isPaused = false;

        animator.SetBool("Pause", false);
        animator.SetBool("Unpause", true);

        buttonBack.interactable = false;
        buttonBack.interactable = true;
        
        buttonResume.interactable = false;
        buttonResume.interactable = true;

        playerController.LockPlayer(false);

        StartCoroutine(UnpauseAnimationTime());
    }

    void UIShow()
    {
            if(fadeCanvasBackground.alpha < 0.8f)
            {
                fadeCanvasBackground.alpha += 2.4f * Time.deltaTime;
                fadeCanvasMenu.alpha = 1f;
            }
            else if(fadeCanvasBackground.alpha >= 0.8f)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
    }

    void UIHide()
    {
        if(fadeCanvasBackground.alpha > 0 || fadeCanvasMenu.alpha > 0)
        {
            fadeCanvasBackground.alpha -= 2.4f * Time.deltaTime;
            fadeCanvasMenu.alpha -= 2.4f * Time.deltaTime;
        }

        if(Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    IEnumerator UnpauseAnimationTime()
    {
        yield return new WaitForSeconds(0.4f);

        hudCanvas.SetActive(true);
        pauseUI.SetActive(false);
    }
}
