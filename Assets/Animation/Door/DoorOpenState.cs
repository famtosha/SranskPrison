using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenState : StateMachineBehaviour
{
    public AudioClip clip;
    private AudioSource audio;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
        audio.PlayOneShot(clip);
    }
}
