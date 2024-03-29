﻿public class ItemHackPanel : ItemPanel
{
    public override OpenRequire openType => OpenRequire.Hack;

    public override bool UseByCharacter(UseAction use)
    {
        bool result = false;
        if (use.isHacker && use.item?.keyID == requireItemID)
        {
            Use();
            result = true;
        }
        return result;
    }
}