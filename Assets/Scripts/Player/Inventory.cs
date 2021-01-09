using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event Action<int, Item> SlotChanged;
    public Item[] inventory = new Item[3];


    public bool AddItemToInventory(int playerID, Item item)
    {
        bool result = false;
        if (inventory[playerID] == null)
        {
            inventory[playerID] = item;
            SlotChanged?.Invoke(playerID, item);
            result = true;
        }
        return result;
    }

    public bool hasItem(int playerID) => inventory[playerID] != null;

    public void DestoryItem(int playerID)
    {
        inventory[playerID] = null;
        SlotChanged?.Invoke(playerID, null);
    }
}