using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used on the Game Handler to keep track of whether or not the person has an item
// That will change how the dungeon works

public class HasItems : MonoBehaviour
{
    public static bool droppedReactorCore = false;
    public static bool droppedWingedShoes = true;
    public static bool droppedGold = false;
    public static bool droppedLockpick = true;
    // Assumes you HAVEN'T dropped anything at the beginning
    void Awake()
    {
        stateReset();
        
    }   

    public void stateReset() {
        droppedReactorCore = false;
        droppedWingedShoes = true;
        droppedGold = false;
        droppedLockpick = true;
        foreach (Item item in ItemList.itemList) {
            if (item.GetName() == "Winged Shoes") 
                droppedWingedShoes = false;
            if (item.GetName() == "Lockpick") 
                droppedWingedShoes = false;
        }
    }

    static float timer = 0;
    static float duration = 0;
    public static void dropGold(float waitTime) {
        timer = Time.time;
        duration = waitTime;
        droppedGold = true;
    }
    // For the continuous effects ie the gold
    void Update() {
        //Debug.Log("Hi");
        if (droppedGold) {
            if (Time.time - timer > duration) 
                PlayerStats.hp = 0;
            Debug.Log("Sad");
        }
    }
}
