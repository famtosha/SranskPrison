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

        var transform = characterMovement.transform;
        var current = (characterMovement.transform.position.ToVector2() + grabDirection).y;
        var min = characterMovement.nearLadder.min.position.y;
        var max = characterMovement.nearLadder.max.position.y;
        var clamped = Mathf.Clamp(current, min, max);

        characterMovement.MovePosition(transform.position.SetY(clamped));
    }

    public override void PassiveMove(Vector2 moveDirection)
    {

    }

    public override void Enter()
    {
        var transform = characterMovement.transform;
        transform.position = transform.position.SetX(characterMovement.nearLadder.gameObject.transform.position.x);
        characterMovement.gravityScale = 0;
        characterMovement.velocity = new Vector2(0, 0);
    }

    public override void Exit()
    {
        characterMovement.gravityScale = characterMovement.defgravity;
    }
}
