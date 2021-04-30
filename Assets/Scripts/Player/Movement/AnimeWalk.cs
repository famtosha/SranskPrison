using UnityEngine;

[CreateAssetMenu(fileName = "New walk", menuName = "Move Data/AnimeWalk")]
public class AnimeWalk : Walk
{
    public float jumpForce;

    public override void Jump()
    {
        if (characterMovement.IsGrounded())
        {
            characterMovement.AddForce(characterMovement.transform.up * jumpForce);
            characterMovement.animatorWrapper.SetTrigger(AnimatorWrapper.jumpTriggerID);
            characterMovement.onJump?.Invoke();
        }
    }
}
