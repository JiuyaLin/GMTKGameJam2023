using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public KeyCode startKey = KeyCode.Space;
    public static bool CreditisOpen = false;
    public string sceneName = "Tutorial Level";


    public GameObject pauseMenuUI;

    void Awake()
    {
    }

    void Start()
    {
        
        //creditsMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(startKey))
        {
            Debug.Log("Start Key pressed");
            SceneManager.LoadScene(sceneName);
        }
    }
}
