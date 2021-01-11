using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(PickupableItem))]

public class NewItemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        PickupableItem myTarget = (PickupableItem)target;
        if(myTarget.item != null)
        {
            EditorGUILayout.ObjectField(myTarget.item, typeof(Item), allowSceneObjects: true);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Item Sprite");
            myTarget.item.itemSprite = (Sprite)EditorGUILayout.ObjectField(myTarget.item.itemSprite, typeof(Sprite), allowSceneObjects: true);
            EditorGUILayout.EndHorizontal();

            myTarget.item.itemID = EditorGUILayout.IntField("Item Number",myTarget.item.itemID);

            if(GUILayout.Button("Reomove item")) myTarget.item = null;
        }
        else
        {
            if (GUILayout.Button("Create item")) myTarget.item = CreateInstance<Item>();
        }
    }
}