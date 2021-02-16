public class ItemPanel : Panel
{
    public override OpenRequire openType => OpenRequire.Item;
    public int requireItemID;

    public override bool UseByCharacter(UseAction use)
    {
        bool result = false;
        if (use?.item?.keyID == requireItemID)
        {
            result = base.UseByCharacter(use);
        }
        return result;
    }
}