using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [Min(0)] public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}