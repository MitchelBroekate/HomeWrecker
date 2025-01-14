using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    #region Variables
    [Header("Linked Variables")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider sensSlider;

    [SerializeField] PlayerController playerController;

    [SerializeField] TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    List<Resolution> filteredResolution = new List<Resolution>();
    float currentRefreshRate;
    int currentResolutionIndex = 0;

    #endregion

    /// <summary>
    /// This function checks if the music sliders already had a playerpref and applies them, if not playerprefs get made, then also sets available resolution in a dropdown menu for resolution switching 
    /// </summary>
    [System.Obsolete]
    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadMaster();
        }
        else
        {
            SetMasterVolume();
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusic();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFX();
        }
        else
        {
            SetSFXVolume();
        }

        if (PlayerPrefs.HasKey("Sens"))
        {
            LoadSens();
        }
        else
        {
            SetSens();
        }

        resolutions = Screen.resolutions;
        filteredResolution = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolution.Add(resolutions[i]);
            }
        }

        List<string> options = new();
        for (int i = 0; i < filteredResolution.Count; i++)
        {
            string resolutionOption = filteredResolution[i].width + "X" + filteredResolution[i].height + " ";
            options.Add(resolutionOption);

            if (filteredResolution[i].width == Screen.width && filteredResolution[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /// <summary>
    /// This function Sets the screen resolution when called
    /// </summary>
    /// <param name="resolutionIndex"></param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolution[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /// <summary>
    /// This function switches between Fullscreen and windowed mode when called
    /// </summary>
    /// <param name="isFullScreen"></param>
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    /// <summary>
    /// This function sets the volume of the audio mixer as the value of the volume slider, and updates or creates a playerpref
    /// </summary>
    public void SetMasterVolume()
    {
        float volumeMaster = masterSlider.value;

        audioMixer.SetFloat("MasterParameter", Mathf.Log10(volumeMaster) * 20);

        PlayerPrefs.SetFloat("MasterVolume", volumeMaster);
    }

    /// <summary>
    /// This function sets the volume of the audio mixer as the value of the volume slider, and updates or creates a playerpref
    /// </summary>
    public void SetMusicVolume()
    {
        float volumeMusic = musicSlider.value;

        audioMixer.SetFloat("MusicParameter", Mathf.Log10(volumeMusic) * 20);

        PlayerPrefs.SetFloat("MusicVolume", volumeMusic);
    }

    /// <summary>
    /// This function sets the volume of the audio mixer as the value of the volume slider, and updates or creates a playerpref
    /// </summary>
    public void SetSFXVolume()
    {
        float volumeSfx = sfxSlider.value;

        audioMixer.SetFloat("SFXParameter", Mathf.Log10(volumeSfx) * 20);

        PlayerPrefs.SetFloat("SFXVolume", volumeSfx);
    }

    public void SetSens()
    {
        float sens = sensSlider.value;

        if(playerController != null)
        {
            playerController.mouseDPI = sens;
        }

        PlayerPrefs.SetFloat("Sens", sens);
    }

    /// <summary>
    /// This function gets the volume playerpref and applies it to the audio mixer and volume slider
    /// </summary>
    void LoadMaster()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        SetMasterVolume();
    }

    /// <summary>
    /// This function gets the volume playerpref and applies it to the audio mixer and volume slider
    /// </summary>
    void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        SetMusicVolume();
    }

    /// <summary>
    /// This function gets the volume playerpref and applies it to the audio mixer and volume slider
    /// </summary>
    void LoadSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetSFXVolume();
    }

    void LoadSens()
    {
        sensSlider.value = PlayerPrefs.GetFloat("Sens");

        SetSens();
    }


}
