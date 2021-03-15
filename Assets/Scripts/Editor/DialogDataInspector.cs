using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(DialogData))]
public class DialogDataInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var dialogData = target as DialogData;

        var chacaters = Resources.FindObjectsOfTypeAll<DialogCharacter>().ToList();
        var chacaterNames = chacaters.Select(x => x.characterName).ToArray();
        dialogData.character = chacaters[EditorGUILayout.Popup("Character", Mathf.Max(chacaters.IndexOf(dialogData.character), 0), chacaterNames)];

        var sprites = dialogData.character.sprites;
        var faceNames = sprites.Select(x => x.name).ToArray();

        dialogData.image = sprites[EditorGUILayout.Popup("Character face", Mathf.Max(sprites.IndexOf(dialogData.image), 0), faceNames)];

        DrawPropertiesExcluding(serializedObject, new string[] { "character", "image", "m_Script" });
    }
}
