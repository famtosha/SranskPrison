using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetHealthText(int health)
    {
        text.SetText(health.ToString());
    }
}