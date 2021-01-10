using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public LayerMask playerLayer;
    public Gun gun;
    public GameObject bulletPrefub;
    public float lookDirection = 1;

    public bool CanSeePlayer => Physics2D.Raycast(transform.position, transform.right, lookDirection, playerLayer);

    public void DealDamage(float damage)
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if (CanSeePlayer) Shoot();
    }

    public void Shoot()
    {
        gun.Shoot(bulletPrefub);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * lookDirection);
    }
}
