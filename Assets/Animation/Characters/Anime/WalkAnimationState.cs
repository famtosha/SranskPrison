using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationState : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    public List<AudioClip> stepSounds;
    private Timer stepCD = new Timer(0.34f);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        audio = animator.gameObject.GetComponent<AudioSource>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stepCD.UpdateTimer(Time.deltaTime);
        if (Mathf.Abs(rb.velocity.magnitude) < 0.1f) animator.SetBool("IsWalking", false);
        if (rb.velocity.y > 0.1f) animator.SetTrigger("Jump");
        if (stepCD.isReady && Mathf.Abs(rb.velocity.x) > 0.01f) PlayStepSound();
    }

    private void PlayStepSound()
    {
        audio.PlayOneShot(stepSounds.GetRandom());
        stepCD.Reset();
    }
}
