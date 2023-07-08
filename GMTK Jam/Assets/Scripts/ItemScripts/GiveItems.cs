using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItems : MonoBehaviour
{
    public GameObject[] levelItems;
    public int maxInventory = 5;
    
    void Start() {
        foreach (GameObject itemObject in levelItems) {
            if (ItemList.itemList.Count >= maxInventory) break;
            ItemList.AddItem(itemObject.GetComponent<Item>());
        }
            
    }

    
}
