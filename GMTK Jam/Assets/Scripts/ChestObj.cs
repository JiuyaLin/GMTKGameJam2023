using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestObj : Interactable
{
    GameObject UI;

    Start() {
        UI = GameObject.FindGameObjectWithTag("ChestUI");
    }

    OnInteract() {
        openChest();
        UI.chestref = gameObject;
    }

    public void openChest() {
        UI.SetActive(true);
        UI.GetComponent<ChestUI>().highlightItems();
        Time.timeScale = 0f;
    }

    public void closeChest() {
        UI.SetActive(false);
        UI.GetComponent<ChestUI>().updateItems();
        Time.timeScale = 1f;
    }

    // separate function 
}
