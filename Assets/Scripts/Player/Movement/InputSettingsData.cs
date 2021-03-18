using UnityEngine;

[CreateAssetMenu(fileName = "New setting", menuName = "Input")]
public class InputSettingsData : ScriptableObject
{
    [Header("All characters")]
    public KeyCode nextCharacter = KeyCode.LeftControl;

    [Header("Movement")]
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;

    [Header("Items")]
    public KeyCode giveItem = KeyCode.T;
    public KeyCode useItem = KeyCode.B;

    [Header("Anime")]
    public KeyCode sneak = KeyCode.K;
    public KeyCode jump = KeyCode.Space;
    public KeyCode kick = KeyCode.L;

    [Header("Gopa")]
    public KeyCode shoot = KeyCode.J;
    public KeyCode meeleAttack = KeyCode.Space;
    public KeyCode pickupZadr = KeyCode.J;

    [Header("Zadr")]
    public KeyCode hackPanel = KeyCode.E;
    public KeyCode bite = KeyCode.L;
    public KeyCode sleep = KeyCode.K;
}
