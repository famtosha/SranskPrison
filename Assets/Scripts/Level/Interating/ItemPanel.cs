using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : Panel
{
    public override OpenRequire openType => OpenRequire.Item;
    public int requireItemID;

    public override void UseByCharacter(UseAction use, out bool isUsed)
    {
        if(use?.item?.itemID == requireItemID)
        {
            base.UseByCharacter(use, out isUsed);
        }
        else
        {
            isUsed = false;
        }
        
    }
}