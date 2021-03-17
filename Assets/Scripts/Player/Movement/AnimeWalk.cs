using UnityEngine;

[CreateAssetMenu(fileName = "New walk", menuName = "Move Data/AnimeWalk")]
public class AnimeWalk : Walk
{
    public float jumpForce;

    public override void Jump()
    {
        if (characterMovement.IsGounded())
        {
            characterMovement.AddForce(characterMovement.transform.up * jumpForce);
        }
    }
}
