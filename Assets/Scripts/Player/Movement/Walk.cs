using UnityEngine;

[CreateAssetMenu(fileName = "New walk", menuName = "Move Data/Walk")]
public class Walk : MoveBehavior
{
    public float moveSpeed;
    public float stopSpeed;
    public float speedLimit;
    public Vector2 moveSpeedMultiply = Vector2.one;

    public override void Jump()
    {

    }

    public override void ActiveMove(Vector2 moveDirection)
    {
        characterMovement.UpdateLookDirection(moveDirection.x);
        moveDirection = characterMovement.transform.TransformDirection(moveDirection);
        Vector2 moveVector = characterMovement.transform.right * moveDirection * moveSpeed;
        if (characterMovement.IsGrounded()) moveVector *= moveSpeedMultiply.x;
        characterMovement.AddForce(moveVector * Time.deltaTime);
        characterMovement.velocity = new Vector2(Mathf.Clamp(characterMovement.velocity.x, -speedLimit, speedLimit), characterMovement.velocity.y);
        if (moveDirection.x == 0f) Stop();
        characterMovement.animatorWrapper.SetBool(AnimatorWrapper.isWalkingBoolID, moveDirection.x > 0.1f);
    }

    private void Stop()
    {
        if (characterMovement.IsGrounded())
        {
            var stopVelocity = new Vector2(characterMovement.velocity.x, 0);

            stopVelocity *= -1;
            stopVelocity /= 2;
            stopVelocity *= stopSpeed;

            characterMovement.AddForce(stopVelocity);
        }
    }

    public override void PassiveMove(Vector2 moveDirection)
    {
        if (characterMovement.IsGrounded())
        {
            Stop();
        }
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }
}
