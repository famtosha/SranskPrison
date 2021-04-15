using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour, IInteraction
{
    [Min(0)] public int sceneIndex;

    public OpenRequire openType => OpenRequire.Closed;

    public void Load()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public bool UseByCharacter(UseAction use) => false;

    public bool UseByAnotherObject()
    {
        Load();
        return true;
    }

    public void ShowInfo() { }

    public void HideInfo() { }
}