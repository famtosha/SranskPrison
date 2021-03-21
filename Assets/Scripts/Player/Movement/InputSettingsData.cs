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
    public KeyCode jump = KeyCode.Space;
    public KeyCode sneak = KeyCode.K;
    public KeyCode kick = KeyCode.L;

    [Header("Gopa")]
    public KeyCode shoot = KeyCode.J;
    public KeyCode meeleAttack = KeyCode.K;
    public KeyCode pickupZadr = KeyCode.L;

    [Header("Zadr")]
    public KeyCode hackPanel = KeyCode.E;
    public KeyCode sleep = KeyCode.K;
    public KeyCode bite = KeyCode.L;
}
