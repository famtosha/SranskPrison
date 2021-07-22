using UnityEngine;

public class RotatingPlatrofm : MonoBehaviour, IInteraction
{
    public OpenRequire openType => OpenRequire.Closed;

    [SerializeField] private float _rotationAngle;
    [SerializeField] private float _rotationSpeed;

    private float _t;
    private bool _isOpened;

    public bool UseByAnotherObject()
    {
        _isOpened = !_isOpened;
        return true;
    }

    private void Update()
    {
        UpdateT();
        UpdateRotation();
    }

    private void UpdateT()
    {
        if (_isOpened) _t += _rotationSpeed * Time.deltaTime / _rotationAngle;
        else _t -= _rotationSpeed * Time.deltaTime / _rotationAngle;
        _t = Mathf.Clamp01(_t);
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, 0, _rotationAngle), _t);
    }

    public void HideInfo() { }
    public void ShowInfo() { }
    public bool UseByCharacter(UseAction use) { return false; }
}
