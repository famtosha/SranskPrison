using System;
using System.Collections;
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

    protected bool canMove = true;

    [SerializeField]
    private int _health;
    public int health
    {
        get => _health;
        set
        {
            _health = value;

            if (_health <= 0)
            {
                if(itemDrop != null)
                {
                    itemDrop.SetActive(true);
                    itemDrop.transform.position = gameObject.transform.position;
                }
                Destroy(gameObject);
            }
        }
    }

    public bool CanSeePlayer()
    {
        bool result = false;
        var hit = Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer | floor);
        if (hit)
        {
            result = hit.collider.gameObject.TryGetComponent(out Character character);
        }
        return result;
    }
    private bool canSeeWall => Physics2D.Raycast(transform.position, transform.right, floorCheckDistance, floor);
    public bool isWayClear => CanSeeGround(out _) && !canSeeWall;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DealDamage(int damage)
    {
        health -= damage;
    }

    protected virtual void Update()
    {
        if (!isWayClear) TurnAround();
        Move();
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
        if (canMove) rb.MovePosition(transform.position + (transform.right * moveSpeed));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * lookDistance);
        if (isWayClear) Gizmos.color = Color.green;
        else Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.right * floorCheckDistance));
        Gizmos.DrawLine(transform.position, transform.position + ((transform.right + -transform.up).normalized * floorCheckDistance));
    }
}
