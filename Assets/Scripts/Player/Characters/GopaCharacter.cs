using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GopaCharacter : Character
{
    public override int playerID => 1;

    public GameObject bulletPrefub;
    public Gun gun;
    public CoolDown meleeCD = new CoolDown(1);
    public CoolDown weaponCD = new CoolDown(1);

    protected override void ActiveUpdate()
    {
        base.ActiveUpdate();
        if (Input.GetKey(KeyCode.J) && weaponCD.isReady) Shoot();
        if (Input.GetKeyDown(KeyCode.Space) && meleeCD.isReady) MeleeAttack();       
    }

    protected override void Update()
    {
        base.Update();
        UpdateTimers();
    }

    public void UpdateTimers()
    {
        meleeCD.UpdateTimer(Time.deltaTime);
        weaponCD.UpdateTimer(Time.deltaTime);
    }

    private void Shoot()
    {
        weaponCD.Reset();
        gun.Shoot(bulletPrefub);
    }

    private void MeleeAttack()
    {
        meleeCD.Reset();
    }
}
