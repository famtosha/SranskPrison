using UnityEngine;

public class MovingPlatform : MonoBehaviour, IInteraction
{
    public OpenRequire openType => OpenRequire.Closed;
    public float speed = 0.01f;
    public Transform end;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 endPosition;
    private Quaternion endRotation;

    private bool _isOpened = false;
    private float moveState;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        endPosition = end.position;
        endRotation = end.rotation;
    }

    public void UseByAnotherObject()
    {
        _isOpened = !_isOpened;
    }

    private void Update()
    {
        if (_isOpened) moveState += speed;
        else moveState -= speed;
        moveState = Mathf.Clamp01(moveState);
        UpdatePlatformPostion();
    }

    public void UpdatePlatformPostion()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, moveState);
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, moveState);
    }

    public void HideInfo() { }
    public void ShowInfo() { }
    public void UseByCharacter(UseAction use, out bool isUsed) { isUsed = false; }
}
