using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStartSave : MonoBehaviour
{
    private static string sceneDie = "Tutorial Level";
    

    void Start() {
        sceneDie = SceneManager.GetActiveScene().name;
        Debug.Log(sceneDie);
    }

    public static string getPreviousScene() {
        return sceneDie;
    }
}
