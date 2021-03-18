using UnityEngine;

public class GopaCharacter : Character
{
    public override int playerID => 1;

    public GameObject bulletPrefub;
    public Gun gun;
    public Timer meleeCD = new Timer(1);
    public Timer weaponCD = new Timer(1);

    private bool holdZadr = false;

    protected override void ActiveUpdate()
    {
        base.ActiveUpdate();
        if (Input.GetKey(InputSettings.current.shoot) && weaponCD.isReady) Shoot();
        if (Input.GetKeyDown(InputSettings.current.meeleAttack) && meleeCD.isReady && !holdZadr) MeleeAttack();
        if (Input.GetKeyDown(InputSettings.current.pickupZadr) && !holdZadr) PickupZadr();
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
        if (zadr != null && zadr.nowTouch != null && zadr.nowTouch.canPickup)
        {
            zadr.nowTouch.isPickuped = true;
            holdZadr = true;
            zadr.nowTouch.wakeUp += DropZadr;
        }
    }

    private void DropZadr()
    {
        var zadr = interacting.zadr;
        if (zadr != null)
        {
            zadr.nowTouch.isPickuped = false;
            holdZadr = false;
            zadr.nowTouch.wakeUp -= DropZadr;
        }
    }

    private void UpdateZadrPosition()
    {
        interacting.zadr.nowTouch.transform.position = transform.position;
    }
}