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

    public static void AddItem(Item item) {
        item.OnGain();
        itemList.Add(item);
    }
    
    public static void RemoveItem(int index) {
        itemList[index].OnDrop();
        itemList.RemoveAt(index);
    }

}
