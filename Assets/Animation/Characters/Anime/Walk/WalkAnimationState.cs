using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationState : StateMachineBehaviour
{
    private AudioSource audio;
    public List<AudioClip> stepSounds;
    private Timer stepCD = new Timer(0.34f);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stepCD.UpdateTimer(Time.deltaTime);
        if (stepCD.isReady) PlayStepSound();
    }

    private void PlayStepSound()
    {
        audio.PlayOneShot(stepSounds.GetRandom());
        stepCD.Reset();
    }
}
