using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterMovement player)) player.UntouchLadder(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterMovement player)) player.TouchLadder();
    }
}