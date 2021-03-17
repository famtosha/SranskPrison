using System;
using System.Collections;
using UnityEngine;

public class ZadrCharacter : Character, IPickupable
{
    public override int playerID => 2;

    public float sleepDuration = 8;
    public float sleepCoolDownDuration = 16;
    public float biteRange = 1;
    public int biteHeal = 1;
    public int biteDamage = 1;
    public GameObject sleepSign;
    public LayerMask enemyLayer;

    private Rigidbody2D rb;
    private Timer sleepCD;
    public Timer biteCD = new Timer(5);

    private bool _isSleeping = false;
    public bool isSleeping
    {
        get => _isSleeping;
        set
        {
            _isSleeping = value;
            var moveBehavior = move.currentMoveBehavior as Walk;
            if (_isSleeping && moveBehavior != null)
            {
                moveBehavior.moveSpeedMultiply = new Vector2(0, 0);
                sleepSign.SetActive(true);
            }
            else
            {
                moveBehavior.moveSpeedMultiply = new Vector2(1, 1);
                sleepSign.SetActive(false);
                wakeUp?.Invoke();
            }
        }
    }

    private bool _isPickuped;

    public event Action wakeUp;

    public bool isPickuped
    {
        get => _isPickuped;
        set
        {
            _isPickuped = value;
            isAvailable = !_isPickuped;
        }
    }

    public bool canPickup => isSleeping;
    protected override bool isHacker => true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sleepCD = new Timer(sleepCoolDownDuration);
    }

    public void StartSleep()
    {
        if (sleepCD.isReady) StartCoroutine(Sleep());
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
        if (Input.GetKeyDown(KeyCode.L)) Bite();
    }

    protected override void Update()
    {
        base.Update();
        sleepCD.UpdateTimer(Time.deltaTime);
        biteCD.UpdateTimer(Time.deltaTime);
    }

    public override void DealDamage(int hearts)
    {
        if (!isSleeping) base.DealDamage(hearts);
    }

    private void Bite()
    {
        if (biteCD.isReady)
        {
            var hit = Physics2D.Raycast(transform.position, transform.right, biteRange, enemyLayer);
            if (hit)
            {
                var enemy = hit.collider.gameObject.GetComponent<Guard>();
                if (enemy != null)
                {
                    enemy.DealDamage(biteDamage);
                    Heal(biteHeal);
                }
            }
        }
        biteCD.Reset();
    }
}