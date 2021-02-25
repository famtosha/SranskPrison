using System.Collections;
using UnityEngine;

public class FatGuard : Guard
{
    public Gun gun;
    public float eatTime;
    public Timer shootCD = new Timer(2);
    public GameObject bulletPrefub;

    private void Shoot()
    {
        if (shootCD.isReady)
        {
            gun.Shoot(bulletPrefub);
            shootCD.Reset();
        }
    }

    public override void Attack()
    {
        base.Attack();
        Shoot();
    }

    protected override void Update()
    {
        base.Update();
        shootCD.UpdateTimer(Time.deltaTime);
        if (health < health.max) StartCoroutine(Eat());
    }

    private IEnumerator Eat()
    {
        canMove = false;
        yield return new WaitForSeconds(eatTime);
        canMove = true;
    }
}