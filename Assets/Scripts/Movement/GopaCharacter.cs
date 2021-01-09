using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD
{
    public float cd;
    public float cdLeft;

    public bool isReady => cdLeft < 0;
    public void UpdateTimer(float time) => cdLeft -= time;
    public void Reset() => cdLeft = cd;

    public CD(float cd)
    {
        this.cd = cd;
    }
}

public class GopaCharacter : Character
{
    public GameObject bulletPrefub;
    public Gun gun;
    public CD meleeCD = new CD(1);
    public CD weaponCD = new CD(1);

    public override void CharacterUpdate()
    {
        base.CharacterUpdate();
        if (Input.GetKey(KeyCode.J) && weaponCD.isReady) Shoot();
        if (Input.GetKeyDown(KeyCode.Space) && meleeCD.isReady) MeleeAttack();
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
