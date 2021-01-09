using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image[] inventoryImages = new Image[3];

    public void SetInventoryImage(int playerID, Sprite sprite)
    {
        inventoryImages[playerID].sprite = sprite;
    }

    public void OnSlotChanged(int playerID, Item item)
    {
        if(item != null)
        {
            SetInventoryImage(playerID, item.itemSprite);
        }
        else
        {
            SetInventoryImage(playerID, null);
        }
    }

    public void ConnectUI(Inventory inventory)
    {
        inventory.SlotChanged += OnSlotChanged;
    }

    public void DisconnectUI(Inventory inventory)
    {
        inventory.SlotChanged -= OnSlotChanged;
    }
}
