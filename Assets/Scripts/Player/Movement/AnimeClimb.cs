using UnityEngine;

[CreateAssetMenu(fileName = "New climb", menuName = "Move Data/AnimeClimb")]
public class AnimeClimb : Climb
{
    public float ladderJumpoffSpeed;

    public override void Jump()
    {
        base.Jump();
        var transform = characterMovement.transform;
        characterMovement.AddForce((transform.right + transform.up).normalized * ladderJumpoffSpeed);
    }
}
