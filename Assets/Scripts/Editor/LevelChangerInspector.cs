using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(LevelChanger))]
public class LevelChangerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelChanger levelChanger = target as LevelChanger;

        if (GUILayout.Button("Set index to next scene"))
        {
            EditorUtility.SetDirty(levelChanger);
            levelChanger.sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }
}
