using UnityEngine;

[CreateAssetMenu(fileName = "New consumable item", menuName = "Custom SO/Items/ConsumableItems")]
public class ConsumableItem : Item
{
    public string itemName;

    public virtual void Use(GameObject user)
    {

    }
}
