public class ItemHackPanel : ItemPanel
{
    public override OpenRequire openType => OpenRequire.Hack;
    public override void UseByCharacter(UseAction use)
    {
        if(use.isHacker && use.item?.itemID == requireItemID)
        {
            Use();
        }
    }
}