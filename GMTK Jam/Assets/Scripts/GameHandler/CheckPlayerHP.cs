using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckPlayerHP : MonoBehaviour
{
    public string gameOverScene = "Game Over";

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.hp > 0) return;
        ItemList.itemList.Clear();
        PlayerStats.resetStats();

        SceneManager.LoadScene(gameOverScene);
        

    }
}
