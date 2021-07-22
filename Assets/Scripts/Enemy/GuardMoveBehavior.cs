using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GuardMoveBehavior : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public LayerMask playerLayer;
    public LayerMask ignore;

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
        if (!IsWayClear() && IsGrounded() && !CanSeePlayer()) TurnAround();
        var velocityX = Mathf.Clamp(rb.velocity.x + (transform.right * moveSpeed).x, -2, 2);
        if (canMove) rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * hight);
    }

    private bool CanSeeWall()
    {
        return Physics2D.Raycast(transform.position, transform.right, floorCheckDistance,~ignore);
    }

    private bool IsWayClear()
    {
        return CanSeeGround() && !CanSeeWall();
    }

    private bool CanSeeGround()
    {
        return Physics2D.Raycast(transform.position, transform.right + -transform.up, floorCheckDistance, ~ignore);
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -transform.up, hight, ~ignore);
    }

    private void TurnAround()
    {
        transform.Rotate(0, 180, 0);
    }

    public bool CanSeePlayer()
    {
        bool result = false;
        var hit = Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer | ~ignore);
        if (hit)
        {
            result = hit.collider.gameObject.HasComponent<Character>();
        }
        return result;
    }
}
