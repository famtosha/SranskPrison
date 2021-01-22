public class ItemHackPanel : ItemPanel
{
    public override OpenRequire openType => OpenRequire.Hack;
    public override void UseByCharacter(UseAction use, out bool isUsed)
    {
        if(use.isHacker && use.item?.itemID == requireItemID)
        {
            Use();
            isUsed = true;
        }
        else
        {
            isUsed = false;
        }
    }
}