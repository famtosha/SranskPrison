using UnityEngine;

[CreateAssetMenu(fileName = "New climb", menuName = "Move Data/Climb")]
public class Climb : MoveBehavior
{
    public float ladderGrapSpeed = 1;

    public override void Jump()
    {
        characterMovement.LeaveLadder();
    }

    public override void ActiveMove(Vector2 moveDirection)
    {
        characterMovement.UpdateLookDirection(moveDirection.x);
        Vector2 grabDirection = characterMovement.transform.up * moveDirection.y * ladderGrapSpeed;
        characterMovement.MovePosition(characterMovement.transform.position.ToVector2() + grabDirection);
    }

    public override void PassiveMove(Vector2 moveDirection)
    {
        //characterMovement.MovePosition(characterMovement.transform.position.ToVector2());
    }

    public override void Enter()
    {
        characterMovement.gravityScale = 0;
        characterMovement.velocity = new Vector2(0, 0);
    }

    public override void Exit()
    {
        characterMovement.gravityScale = characterMovement.defgravity;
    }
}
