public interface IInteraction
{
    void UseByCharacter(UseAction use, out bool isUsed);
    void UseByAnotherObject();
    OpenRequire openType { get; }
    void ShowInfo();
    void HideInfo();
}