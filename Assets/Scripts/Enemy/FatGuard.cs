using System.Collections;
using UnityEngine;

public class FatGuard : Guard
{
    public Gun gun;
    public CoolDown shootCD = new CoolDown(2);
    public GameObject bulletPrefub;
    public GameObject sleepSign;

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
    }
}