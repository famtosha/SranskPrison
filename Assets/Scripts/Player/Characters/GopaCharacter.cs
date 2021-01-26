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

    private bool holdZadr = false;

    protected override void ActiveUpdate()
    {
        base.ActiveUpdate();
        if (Input.GetKey(KeyCode.J) && weaponCD.isReady) Shoot();
        if (Input.GetKeyDown(KeyCode.Space) && meleeCD.isReady && !holdZadr) MeleeAttack();
        if (Input.GetKeyDown(KeyCode.K) && !holdZadr) PickupZadr();
    }

    protected override void Update()
    {
        base.Update();
        UpdateTimers();
        if (holdZadr) UpdateZadrPosition();
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

    private void PickupZadr()
    {
        var zadr = interacting.zadr;
        if(zadr != null && zadr.canPickup)
        {
            zadr.isPickuped = true;
            holdZadr = true;
            zadr.wakeUp += DropZadr;
        }
    }

    private void DropZadr()
    {
        var zadr = interacting.zadr;
        if(zadr != null)
        {
            zadr.isPickuped = false;
            holdZadr = false;
            zadr.wakeUp -= DropZadr;
        }
    }

    private void UpdateZadrPosition()
    {
        interacting.zadr.transform.position = transform.position;
    }
}
