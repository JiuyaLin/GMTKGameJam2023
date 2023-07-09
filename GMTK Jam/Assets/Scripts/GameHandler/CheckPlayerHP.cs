using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckPlayerHP : MonoBehaviour
{
    public string gameOverScene = "Game Over";
    private static List<Item> startItems;

    void Start() {
        startItems = ItemList.itemList;
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.hp > 0) return;
        ItemList.itemList.Clear();
        PlayerStats.resetStats();
        foreach (Item item in startItems)
            ItemList.AddItem(item);

        SceneManager.LoadScene(gameOverScene);
        

    }
}
