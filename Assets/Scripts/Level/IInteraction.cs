public interface IInteraction
{
    void UseByCharacter(UseAction use);
    void UseByAnotherObject();
    OpenRequire openType { get; }
    void ShowInfo();
    void HideInfo();
}