using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class GameHandler_PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public static float volumeLevel = 1.0f;


    public GameObject pauseMenuUI;
    public GameObject creditsMenuUI;
    public AudioMixer mixer;
    private Slider sliderVolumeCtrl;
   


    void Awake()
    {
        SetLevel(volumeLevel);
        GameObject sliderTemp = GameObject.Find("PauseMenuSlider");
        if (sliderTemp != null) {
            sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
            sliderVolumeCtrl.value = volumeLevel;
        }
    }


    void Start()
    {
        Resume();
    }


    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            if (GameisPaused) {
                Resume();
            } else {
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
        creditsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }


    public void OpenCredits()
    {
        pauseMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
    }


    public void CloseCredits()
    {
        pauseMenuUI.SetActive(true);
        creditsMenuUI.SetActive(false);
    }


    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("AudioVolume", Mathf.Log10(sliderValue) * 20);
        volumeLevel = sliderValue;
    }
}