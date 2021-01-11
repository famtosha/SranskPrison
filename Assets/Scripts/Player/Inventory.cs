using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static event Action<int, Item> SlotChanged;
    public Item[] inventory = new Item[3];

    public void ItemUpdate(int playerID)
    {
        SlotChanged?.Invoke(playerID, inventory[playerID]);
    }

    public bool AddItemToInventory(int playerID, Item item)
    {
        bool result = false;
        if (inventory[playerID] == null)
        {
            inventory[playerID] = item;
            ItemUpdate(playerID);
            result = true;
        }
        return result;
    }

    public bool hasItem(int playerID)
    {
        return inventory[playerID] != null;
    }

    public void SwitchItems(int firstPlayerID, int secondPlayerID)
    {
        var temp = inventory[firstPlayerID];
        inventory[firstPlayerID] = inventory[secondPlayerID];
        inventory[secondPlayerID] = temp;
        ItemUpdate(firstPlayerID);
        ItemUpdate(secondPlayerID);
    }

    public void DestoryItem(int playerID)
    {
        inventory[playerID] = null;
        ItemUpdate(playerID);
    }
}