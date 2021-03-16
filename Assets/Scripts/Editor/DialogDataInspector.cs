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
        var chacaters = EditorExtention.FindAssetsByType<DialogCharacter>();
        var chacaterNames = chacaters.Select(x => x.characterName).ToArray();

        SerializedProperty character = serializedObject.FindProperty("character");
        SerializedProperty image = serializedObject.FindProperty("image");

        character.objectReferenceValue = chacaters[EditorGUILayout.Popup("Character", Mathf.Max(chacaters.IndexOf(character.As<DialogCharacter>()), 0), chacaterNames)];

        var sprites = ((DialogCharacter)character.objectReferenceValue).sprites;
        var faceNames = sprites.Select(x => x.name).ToArray();
        image.objectReferenceValue = sprites[EditorGUILayout.Popup("Character face", Mathf.Max(sprites.IndexOf(character.As<Sprite>()), 0), faceNames)];

        serializedObject.ApplyModifiedProperties();

        DrawPropertiesExcluding(serializedObject, new string[] { "character", "image", "m_Script" });
    }
}
