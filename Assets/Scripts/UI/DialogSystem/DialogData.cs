using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialog", menuName = "DialogSystem/Dialog")]
public class DialogData : ScriptableObject
{
    public Characters player;
    public Sprite authorImage;
    public float textSpeed = 10;
    public string text;
    public float exitTime = 3;
    public DialogData nextDialog;
}
