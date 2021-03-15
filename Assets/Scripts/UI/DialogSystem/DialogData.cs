using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialog", menuName = "DialogSystem/Dialog")]
public class DialogData : ScriptableObject
{
    public DialogCharacter character;
    public Sprite image;
    public float textSpeed = 10;
    public string text;
    public float exitTime = 3;
    public DialogData nextDialog;
}
