using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    public OpenRequire openType => OpenRequire.Closed;

    private bool isOpened = false;
    private Animator doorOpenAnimation;

    public void HideInfo() { }
    public void ShowInfo() { }

    private void Start()
    {
        doorOpenAnimation = GetComponent<Animator>();
    }

    protected virtual void Use()
    {
        isOpened = !isOpened;
        if (isOpened)
        {
            doorOpenAnimation.Play("DoorOpen");
        }
        else
        {
            doorOpenAnimation.Play("DoorClose");
        }
    }

    public bool UseByAnotherObject()
    {
        Use();
        return true;
    }

    public bool UseByCharacter(UseAction use)
    {
        return false;
    }
}