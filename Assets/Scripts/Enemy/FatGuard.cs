using UnityEngine;

public class FatGuard : Guard
{
    public Gun gun;
    public CoolDown shootCD = new CoolDown(2);
    public GameObject bulletPrefub;

    public void Shoot()
    {
        gun.Shoot(bulletPrefub);
        shootCD.Reset();
    }

    protected override void Update()
    {
        base.Update();
        shootCD.UpdateTimer(Time.deltaTime);
        if (CanSeePlayer && shootCD.isReady) Shoot();
    }
}
