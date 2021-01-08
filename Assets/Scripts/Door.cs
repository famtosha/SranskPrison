using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    public void HideInfo(){}
    public void ShowInfo(){}
    private Animator doorOpenAnimation;

    private void Start()
    {
        doorOpenAnimation = GetComponent<Animator>();
    }

    public void Use()
    {
        doorOpenAnimation.Play("DoorOpen");
    }
}
