using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : Panel, IInterationWithItem
{
    public PickupableItem requireItem;

    public bool UseWithItem(PickupableItem item)
    {
        bool result = false;
        if(item == requireItem)
        {
            Use();
            result = true;
        }
        return result;
    }

    protected override bool CanUse()
    {
        return false;
    }
}
