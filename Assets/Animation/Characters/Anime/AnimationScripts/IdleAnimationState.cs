using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationState : StateMachineBehaviour
{
    private Rigidbody2D rb;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(rb.velocity.magnitude) > 0.01f)
        {
            animator.SetBool("IsWalking", true);
        }
        if (rb.velocity.y > 0.1f)
        {
            animator.SetTrigger("Jump");
        }
    }
}
