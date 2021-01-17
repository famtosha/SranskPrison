using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeCharacter : Character
{
    public override int playerID => 0;
    public LayerMask level;
    public LayerMask zadr;

    private bool isHoldDuck = false;

    private bool _isDuck = false;
    public bool isDuck
    {
        get => _isDuck;
        set
        {
            if (value == _isDuck) return;
            _isDuck = value;
            if (_isDuck)
            {
                move.moveSpeed = 5;
                transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
            }
            else
            {
                move.moveSpeed = 15;
                transform.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
            }
        }
    }

    protected override void ActiveUpdate()
    {
        base.ActiveUpdate();

        if (Input.GetKeyDown(KeyCode.J)) move.Jump();
        if (Input.GetKeyDown(KeyCode.L)) Kick();

        isHoldDuck = Input.GetKey(KeyCode.K);
        SitDown();
        StandUp();
    }

    private void SitDown()
    {
        if (!isDuck && isHoldDuck) isDuck = true;
    }

    private void Kick()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, 1, zadr);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent(out ZadrCharacter zadr))
                {
                    var zadrRB = zadr.gameObject.GetComponent<Rigidbody2D>();
                    var kickForce = zadr.transform.position - transform.position;
                    kickForce = kickForce.normalized;
                    kickForce *= 1000;
                    zadrRB.AddForce(kickForce);
                    return;
                }
            }
        }
    }

    private void StandUp()
    {
        if (!isHoldDuck && CanStandUp())
        {
            isDuck = false;
        }
    }

    private bool CanStandUp()
    {
        return !Physics2D.Raycast(transform.position, transform.up, 1, level);
    }
}
