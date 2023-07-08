using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestObj : Interactable
{
    ChestUI UIscript;
    GameObject UI;

    bool chestOpened;
    public bool chestFilled;

    void Start() {
        UIscript = GameObject.FindGameObjectWithTag("HUD").GetComponent<ChestUI>();
        Debug.Log(UIscript);
        UI = GameObject.FindGameObjectWithTag("HUD").transform.GetChild(1).gameObject;
    }

    public override void OnInteract() {
        Debug.Log("hi");
        if (!chestFilled) {
            openChest();
            chestOpened = true;
            UIscript.chestref = this;
        } else {
            Debug.Log("Chest Full!");
            // display msg saying its full 
        }
    }

    void Update() {
        if (chestOpened && Input.GetMouseButtonDown(1)) {
            closeChest();
        }
    }

    public void openChest() {
        UI.SetActive(true);
        UIscript.highlightItems();
        Time.timeScale = 0f;
    }

    public void closeChest() {
        UI.SetActive(false);
        chestOpened = false;
        UIscript.updateItems();
        Time.timeScale = 1f;
    }
}
