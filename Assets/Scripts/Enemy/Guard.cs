using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour, IDamagable
{
    public LayerMask playerLayer;
    public LayerMask floor;
    public float moveSpeed;
    public float floorCheckDistance;
    public float lookDistance = 1;
    public GameObject itemDrop;
    public GuardStateMachine stateMachine;
    [SerializeField] public Health health = new Health(0, 4, 4);

    protected bool canMove = true;

    private bool canSeeWall => Physics2D.Raycast(transform.position, transform.right, floorCheckDistance, floor);
    public bool IsWayClear()
    {
        return CanSeeGround(out _) && !canSeeWall;
    }

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health.Death += Death;
        stateMachine = new GuardStateMachine(this);
    }

    protected virtual void Update()
    {
        stateMachine.StateUpdate();
    }

    private bool CanSeeGround(out Vector2 postion)
    {
        Vector2 checkDirection = transform.right + -transform.up;
        var result = Physics2D.Raycast(transform.position, checkDirection, floorCheckDistance, floor);
        postion = result.point;
        return result;
    }

    private void TurnAround()
    {
        transform.Rotate(0, 180, 0);
    }

    public void Move()
    {
        if (!IsWayClear()) TurnAround();
        if (canMove) rb.MovePosition(transform.position + (transform.right * moveSpeed));
    }

    public virtual void Attack()
    {

    }

    public void DropItem()
    {
        if (itemDrop == null) return;
        itemDrop.SetActive(true);
        itemDrop.transform.position = gameObject.transform.position;
        itemDrop.transform.SetParent(null);
    }

    public bool CanSeePlayer()
    {
        bool result = false;
        var hit = Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer | floor);
        if (hit)
        {
            result = hit.collider.gameObject.TryGetComponent(out Character _);
        }
        return result;
    }

    public void DealDamage(int damage)
    {
        health.health -= damage;
    }

    public void Death()
    {
        DropItem();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * lookDistance);
        if (IsWayClear()) Gizmos.color = Color.green;
        else Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.right * floorCheckDistance));
        Gizmos.DrawLine(transform.position, transform.position + ((transform.right + -transform.up).normalized * floorCheckDistance));
    }
}