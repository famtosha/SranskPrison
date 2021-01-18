using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public LayerMask playerLayer;
    public LayerMask floor;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float floorCheckDistance;
    public Gun gun;
    public GameObject bulletPrefub;
    public CoolDown shootCD = new CoolDown(2);
    public float lookDistance = 1;

    public bool CanSeePlayer => Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void DealDamage(int damage)
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        shootCD.UpdateTimer(Time.deltaTime);
        if (CanSeePlayer && shootCD.isReady) Shoot();
        if (!isWayClear) TurnAround();
        Move();
    }

    public void Shoot()
    {
        gun.Shoot(bulletPrefub);
        shootCD.Reset();
    }

    private bool CanSeeGround(out Vector2 postion)
    {
        Vector2 checkDirection = transform.right + -transform.up;
        var result = Physics2D.Raycast(transform.position, checkDirection, floorCheckDistance, floor);
        postion = result.point;
        return result;
    }

    private bool CanSeeWall => Physics2D.Raycast(transform.position, transform.right, floorCheckDistance, floor);

    public bool isWayClear => CanSeeGround(out _) && !CanSeeWall;

    private void TurnAround()
    {
        transform.Rotate(0, 180, 0);
    }

    public void Move()
    {
        rb.MovePosition(transform.position + (transform.right * moveSpeed));
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
