using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void OnHealthChanged(int health)
    {
        text.SetText(health.ToString());
    }
}