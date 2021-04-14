using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationState : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private CharacterMovement movement;
    private bool isJump = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        movement = animator.gameObject.GetComponent<CharacterMovement>();
        movement.onJump += PlayJumpAnimation;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movement.onJump -= PlayJumpAnimation;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(rb.velocity.x) > 0.01f) animator.SetBool("IsWalking", true);
        if (isJump)
        {
            animator.SetTrigger("Jump");
            isJump = false;
        }
    }
    private void PlayJumpAnimation()
    {
        isJump = true;
    }
}
