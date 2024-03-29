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
        if (item != null)
        {
            SetInventoryImage(playerID, item.itemSprite);
        }
        else
        {
            SetInventoryImage(playerID, null);
        }
    }

    private void OnEnable()
    {
        Inventory.SlotChanged += OnSlotChanged;
    }

    private void OnDisable()
    {
        Inventory.SlotChanged -= OnSlotChanged;
    }
}