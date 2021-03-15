using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New chacater", menuName = "DialogSystem/Character")]
public class DialogCharacter : ScriptableObject
{
    public string characterName;
    public List<Sprite> sprites = new List<Sprite>();
}
