using System;
using UnityEngine;

public class Inventory
{
    public static event Action<int, Item> SlotChanged;
    public Item[] inventory = new Item[3];

    public void ItemUpdate(int playerID)
    {
        SlotChanged?.Invoke(playerID, inventory[playerID]);
    }

    public bool AddItem(int playerID, Item item)
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

    public bool HasItem(int playerID)
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

    public Item TakeItem(int playerID)
    {
        var temp = inventory[playerID];
        inventory[playerID] = null;
        ItemUpdate(playerID);
        return temp;
    }

    public void DestoryItem(int playerID)
    {
        TakeItem(playerID);
    }
}