using UnityEngine;

public class CharactersHealthUI : MonoBehaviour
{
    public HealthUI[] healthUIs = new HealthUI[3];

    private void OnEnable() => Health.HealthCanged += OnHealthChanged;
    private void OnDisable() => Health.HealthCanged -= OnHealthChanged;

    private void OnHealthChanged(int playerID, int newHealth)
    {
        healthUIs[playerID].SetHealthText(newHealth);
    }
}
