using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameHandler_PauseMenu : MonoBehaviour
{

    public KeyCode pauseKey = KeyCode.Escape;
    public static bool GameisPaused = false;
    public static bool CreditisOpen = false;

    public GameObject pauseMenuUI;
    public GameObject creditsMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;
    

    void Awake()
    {
        SetLevel(volumeLevel);
        GameObject sliderTemp = GameObject.Find("PauseMenuSlider");
        if (sliderTemp != null)
        {
            sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
            sliderVolumeCtrl.value = volumeLevel;
        }
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
        GameisPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        creditsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        if (CreditisOpen)
        {
            CloseCredits();
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void OpenCredits()
    {
        pauseMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
        CreditisOpen = true;
    }

    public void CloseCredits()
    {
        pauseMenuUI.SetActive(true);
        creditsMenuUI.SetActive(false);
        CreditisOpen = false;
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("AudioVolume", Mathf.Log10(sliderValue) * 20);
        volumeLevel = sliderValue;
    }
}

