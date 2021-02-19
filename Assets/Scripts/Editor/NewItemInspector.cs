using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PickableKey))]
public class NewItemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var myTarget = target as PickableKey;

        if (myTarget.item != null)
        {
            var key = myTarget.item as Key;
            EditorUtility.SetDirty(myTarget);

            EditorGUILayout.ObjectField(myTarget.item, typeof(PickableKey), allowSceneObjects: true);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Item Sprite");
            myTarget.item.itemSprite = (Sprite)EditorGUILayout.ObjectField(myTarget.item.itemSprite, typeof(Sprite), allowSceneObjects: true);
            EditorGUILayout.EndHorizontal();

            key.keyID = EditorGUILayout.IntField("Item Number", key.keyID);

            if (GUILayout.Button("Remove item")) myTarget.item = null;
        }
        else
        {
            if (GUILayout.Button("Create item")) myTarget.item = CreateInstance<Key>();
        }
    }
}