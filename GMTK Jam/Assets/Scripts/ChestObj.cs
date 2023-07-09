using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestObj : Interactable
{
    ChestUI UIscript;
    GameObject UI;
    public List<Transform> activates = new List<Transform>();
    private Animator anim;

    public bool chestOpened;
    public bool chestFilled;

    void Start() {
        UIscript = GameObject.FindGameObjectWithTag("HUD").GetComponent<ChestUI>();
        // Debug.Log(UIscript);
        UI = GameObject.FindGameObjectWithTag("HUD").transform.GetChild(2).gameObject;
        anim = transform.GetChild(1).GetComponent<Animator>();
    }

    public override void OnInteract() {
        // Debug.Log("hi");
        if (!chestFilled) {
            openChest();
            chestOpened = true;
            UIscript.setChestRef(this);
        } else {
            // Debug.Log("Chest Full!");
            // display msg saying its full 
        }
    }

    void Update() {
        if (chestOpened && Input.GetMouseButtonDown(1)) {
            closeChest();
        }
    }

    public void openChest() {
        UIscript.highlightItems();
        Time.timeScale = 0f;
    }

    public void closeChest() {
        // Debug.Log("closed!");
        anim.SetFloat("Speed", 1.0f);
        transform.GetChild(1).GetComponent<Animator>().Play("Chest");
        UIscript.unhighlight();
        chestOpened = false;
        UIscript.updateItems();
        Time.timeScale = 1f;
        if (chestFilled)
        {
            GetComponent<AudioSource>().clip = (FindAnyObjectByType(typeof(SoundHolder)) as SoundHolder).openChest;
            GetComponent<AudioSource>().Play();
        }
        foreach (Transform transformToActivate in activates)
        {
            if (chestFilled)
            {
                foreach (SignalActivatable activatable in transformToActivate.GetComponentsInChildren<SignalActivatable>())
                {
                    activatable.OnSignalActivate();
                }
            }
            else
            {
                foreach (SignalDeactivatable deActivatable in transformToActivate.GetComponentsInChildren<SignalDeactivatable>())
                {
                    deActivatable.OnSignalDeactivate();
                }
            }
        }
    }
}
