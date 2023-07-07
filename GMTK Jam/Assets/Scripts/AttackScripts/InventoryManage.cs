using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    static HashSet<string> inventoryList;

    public static void addItem(string itemName) {
        inventoryList.Add(itemName);
    }

    public static void removeItem(string itemName) {
        inventory.Remove(itemName);
    }
}
