using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public LayerMask playerLayer;
    public Gun gun;
    public GameObject bulletPrefub;
    public CoolDown shootCD = new CoolDown(2);
    public float lookDistance = 1;

    public bool CanSeePlayer => Physics2D.Raycast(transform.position, transform.right, lookDistance, playerLayer);

    public void DealDamage(int damage)
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        shootCD.UpdateTimer(Time.deltaTime);
        if (CanSeePlayer && shootCD.isReady) Shoot();
    }

    public void Shoot()
    {
        gun.Shoot(bulletPrefub);
        shootCD.Reset();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * lookDistance);
    }
}
