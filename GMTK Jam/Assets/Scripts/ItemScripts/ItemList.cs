using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemList
{
    public static List<Item> itemList;

    static ItemList()
    {
        itemList = new List<Item>();
    }

    public static void addItem(GameObject player, Item item) {
        item.onGain(player);
        itemList.Add(item);
    }
    
    public static void removeItem(GameObject player, int index) {
        itemList[index].onDrop(player);
        itemList.RemoveAt(index);
    }

}
