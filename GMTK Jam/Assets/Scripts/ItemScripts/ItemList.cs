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

    public static void AddItem(ThirdPersonMovement2 player, Item item) {
        item.OnGain(player);
        itemList.Add(item);
    }
    
    public static void RemoveItem(ThirdPersonMovement2 player, int index) {
        itemList[index].OnDrop(player);
        itemList.RemoveAt(index);
    }

}
