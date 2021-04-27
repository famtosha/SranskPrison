using UnityEngine;
using UnityEngine.Events;


public class MiniGameBehaviour : MonoBehaviour
{
    public UnityEvent GameCompleted;

    public GameObject minigameGameObject;

    public void StartGame()
    {
        minigameGameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CompleteGame()
    {
        GameCompleted.Invoke();
        Time.timeScale = 1;
        minigameGameObject.SetActive(false);
    }
}