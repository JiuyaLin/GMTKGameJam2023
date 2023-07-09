using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItems : MonoBehaviour
{
    public GameObject[] levelItemPrefabs;
    public int maxInventory = 5;
    
    void Awake() {
        foreach (GameObject itemObject in levelItemPrefabs) {
            if (ItemList.itemList.Count >= maxInventory) break;
            ItemList.AddItem(itemObject.GetComponent<Item>());
        }
            
    }

    
}
