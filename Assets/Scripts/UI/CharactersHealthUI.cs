using UnityEngine;

public class CharactersHealthUI : MonoBehaviour
{
    public HealthUI[] healthUIs = new HealthUI[3];

    private void OnEnable()
    {
        ConnectUI();
    }

    private void OnDisable()
    {
        DisconnectUI();
    }

    private void ConnectUI()
    {
        foreach (var character in FindObjectsOfType<Character>())
        {
            character.health.HealthChanged += healthUIs[character.playerID].OnHealthChanged;
        }
    }

    private void DisconnectUI()
    {
        foreach (var character in FindObjectsOfType<Character>())
        {
            character.health.HealthChanged -= healthUIs[character.playerID].OnHealthChanged;
        }
    }
}