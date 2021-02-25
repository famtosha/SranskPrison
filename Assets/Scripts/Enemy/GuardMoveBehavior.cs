using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GuardMoveBehavior : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public LayerMask playerLayer;
    public LayerMask floorLayer;

    public float moveSpeed;
    public float floorCheckDistance;
    public float lookDistance;
    public float hight;
    public bool canMove { get; set; } = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        if (!IsWayClear() && IsGrounded()) TurnAround();
        var velocityX = Mathf.Clamp(rb.velocity.x + (transform.right * moveSpeed).x, -2, 2);
        if (canMove) rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private bool CanSeeWall()
    {
        return Physics2D.Raycast(transform.position, transform.right, floorCheckDistance, floorLayer);
    }

    private bool IsWayClear()
    {
        return CanSeeGround() && !CanSeeWall();
    }

    private bool CanSeeGround()
    {
        return Physics2D.Raycast(transform.position, transform.right + -transform.up, floorCheckDistance, floorLayer);
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -transform.up, hight, floorLayer);
    }

    private void TurnAround()
    {
        transform.Rotate(0, 180, 0);
    }

    public bool CanSeePlayer()
    {
        bool result = false;
        var hit = Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer | floorLayer);
        if (hit)
        {
            result = hit.collider.gameObject.HasComponent<Character>();
        }
        return result;
    }
}
