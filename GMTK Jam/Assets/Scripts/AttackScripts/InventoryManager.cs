using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    public static HashSet<string> inventoryList;

    public static void addItem(string itemName) {
        inventoryList.Add(itemName);
    }

    public static void removeItem(string itemName) {
        inventoryList.Remove(itemName);
    }
}
