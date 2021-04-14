using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationState : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    private CharacterMovement movement;
    public List<AudioClip> stepSounds;
    private Timer stepCD = new Timer(0.34f);

    private bool isJump = false;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        audio = animator.gameObject.GetComponent<AudioSource>();
        movement = animator.gameObject.GetComponent<CharacterMovement>();
        movement.onJump += PlayJumpAnimation;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movement.onJump -= PlayJumpAnimation;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stepCD.UpdateTimer(Time.deltaTime);
        if (Mathf.Abs(rb.velocity.x) < 0.1f) animator.SetBool("IsWalking", false);
        if (stepCD.isReady && Mathf.Abs(rb.velocity.x) > 0.01f) PlayStepSound();
        if (isJump)
        {
            animator.SetTrigger("Jump");
            isJump = false;
        }
    }

    private void PlayStepSound()
    {
        audio.PlayOneShot(stepSounds.GetRandom());
        stepCD.Reset();
    }

    private void PlayJumpAnimation()
    {
        isJump = true;
    }
}
