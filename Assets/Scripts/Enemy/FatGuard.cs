using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FatGuard : Guard
{
    public Gun gun;
    public CoolDown shootCD = new CoolDown(2);
    public CoolDown eatCD = new CoolDown(10);
    public float eatTime = 5;
    public GameObject bulletPrefub;
    public GameObject sleepSign;

    private void Shoot()
    {
        gun.Shoot(bulletPrefub);
        shootCD.Reset();
    }

    private void StartEat()
    {
        StartCoroutine(eat());
        IEnumerator eat()
        {
            canMove = false;
            sleepSign.SetActive(true);
            yield return new WaitForSeconds(eatTime);
            health += 1;
            eatCD.Reset();
            canMove = true;
            sleepSign.SetActive(false);
        }
    }

    protected override void Update()
    {
        base.Update();
        shootCD.UpdateTimer(Time.deltaTime);
        eatCD.UpdateTimer(Time.deltaTime);
        if (CanSeePlayer() && shootCD.isReady) Shoot();
        if (health < 4 && eatCD.isReady && !CanSeePlayer()) StartEat();
    }
}
