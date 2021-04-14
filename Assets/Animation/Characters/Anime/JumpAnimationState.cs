using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimationState : StateMachineBehaviour
{
    public List<AudioClip> jumpSound = new List<AudioClip>();

    private AudioSource audio;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
        audio.PlayOneShot(jumpSound.GetRandom());
    }
}
