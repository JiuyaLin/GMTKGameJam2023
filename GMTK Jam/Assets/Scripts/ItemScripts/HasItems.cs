using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used on the Game Handler to keep track of whether or not the person has an item
// That will change how the dungeon works

public class HasItems : MonoBehaviour
{
    public static bool droppedReactorCore = false;
    public static bool droppedLockpick = true; // assumes you don't have it to start with
    public static bool droppedWingedShoes = true;
    

    // Assumes you HAVEN'T dropped anything at the beginning
    void Awake()
    {
        droppedReactorCore = false;
        droppedLockpick = true;
        droppedWingedShoes = true;
    }   
}
