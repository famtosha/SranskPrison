using UnityEngine;

public class InputSettings : MonoBehaviour
{
    public static InputSettingsData current;
    public InputSettingsData _current;

    private void Awake()
    {
        current = _current;
    }
}
