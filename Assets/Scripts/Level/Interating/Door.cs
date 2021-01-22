using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    public void HideInfo(){}
    public void ShowInfo(){}
    private Animator doorOpenAnimation;

    public OpenRequire openType => OpenRequire.Closed;

    private void Start()
    {
        doorOpenAnimation = GetComponent<Animator>();
    }

    protected virtual void Use()
    {
        doorOpenAnimation.Play("DoorOpen");
    }

    public void UseByAnotherObject()
    {
        Use();
    }

    public void UseByCharacter(UseAction use, out bool isUsed)
    {
        isUsed = false;
    }
}
