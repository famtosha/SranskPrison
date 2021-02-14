public interface IInteraction
{
    bool UseByCharacter(UseAction use);
    bool UseByAnotherObject();
    OpenRequire openType { get; }
    void ShowInfo();
    void HideInfo();
}