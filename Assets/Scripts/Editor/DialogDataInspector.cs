using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

[CustomEditor(typeof(DialogData))]
public class DialogDataInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var dialogData = target as DialogData;
        bool isChanged = false;

        EditorUtility.SetDirty(dialogData);
        var chacaters = EditorExtention.FindAssetsByType<DialogCharacter>();
        var chacaterNames = chacaters.Select(x => x.characterName).ToArray();

        var prefCharacter = dialogData.character;
        dialogData.character = chacaters[EditorGUILayout.Popup("Character", Mathf.Max(chacaters.IndexOf(dialogData.character), 0), chacaterNames)];
        isChanged = dialogData.character != prefCharacter;

        var sprites = dialogData.character.sprites;
        var faceNames = sprites.Select(x => x.name).ToArray();

        var prefImage = dialogData.image;
        dialogData.image = sprites[EditorGUILayout.Popup("Character face", Mathf.Max(sprites.IndexOf(dialogData.image), 0), faceNames)];
        isChanged = isChanged || dialogData.image != prefImage;

        DrawPropertiesExcluding(serializedObject, new string[] { "character", "image", "m_Script" });

        if (isChanged) AssetDatabase.SaveAssets();
    }
}
