using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZadrCharacter : Character
{
    public override int playerID => 2;
    public float sleepDuration = 8;
    public float sleepCoolDownDuration = 16;
    private Rigidbody2D rb;
    private CoolDown sleepCD;

    private bool _isSleeping = false;
    public bool isSleeping
    {
        get => _isSleeping;
        set
        {
            _isSleeping = value;
            if (_isSleeping)
            {
                move.moveSpeed = 0;
                rb.mass = 99999999;
            }
            else
            {
                move.moveSpeed = 5;
                rb.mass = 1;
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sleepCD = new CoolDown(sleepCoolDownDuration);
    }

    public void StartSleep()
    {
        StartCoroutine(Sleep());
    }

    private IEnumerator Sleep()
    {
        isSleeping = true;
        yield return new WaitForSeconds(sleepDuration);
        isSleeping = false;
        sleepCD.Reset();
    }

    protected override void ActiveUpdate()
    {
        base.ActiveUpdate();
        if (Input.GetKeyDown(KeyCode.K)) StartSleep();
    }

    protected override void Update()
    {
        base.Update();
        sleepCD.UpdateTimer(Time.deltaTime);
    }

    public override void DealDamage(float damage)
    {
        if (!isSleeping) base.DealDamage(damage);
    }
}
