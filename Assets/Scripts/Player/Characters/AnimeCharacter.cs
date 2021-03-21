using UnityEngine;

public class AnimeCharacter : Character
{
    public override int playerID => 0;
    public LayerMask level;
    public LayerMask zadr;
    public Timer kickCD = new Timer(3);
    public float kickForce;
    public float duckSize = 0.5f;
    public float duckSpeed = 0.5f;
    public float kickRange = 1;
    public float kickAngle = 0;

    public GameObject kickAngeArrow;

    private bool _isSelectingkickAngle;
    public bool isSelectingkickAngle
    {
        get => _isSelectingkickAngle;
        set
        {
            _isSelectingkickAngle = value;
            kickAngeArrow.SetActive(value);
        }
    }

    private bool isHoldDuck = false;

    private bool _isDuck = false;
    public bool isDuck
    {
        get => _isDuck;
        set
        {
            if (value == _isDuck) return;
            _isDuck = value;
            var moveBehavior = move.walk as Walk;
            if (_isDuck)
            {
                moveBehavior.moveSpeedMultiply *= duckSpeed;
                move.sizeMultiply.y *= duckSize;
                transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
            }
            else
            {
                moveBehavior.moveSpeedMultiply /= duckSpeed;
                move.sizeMultiply.y /= duckSize;
                transform.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
            }
        }
    }

    protected override void ActiveUpdate()
    {
        base.ActiveUpdate();
        KickUpdate();
        isHoldDuck = Input.GetKey(InputSettings.current.sneak);
        SitDown();
        StandUp();
    }

    private void SitDown()
    {
        if (!isDuck && isHoldDuck) isDuck = true;
    }

    public override void Deselect()
    {
        base.Deselect();
        isSelectingkickAngle = false;
    }

    private void UpdateKickAngle()
    {
        if (!TryGetZadr(out _)) isSelectingkickAngle = false;
        kickAngle += 0.01f;
        kickAngeArrow.transform.up = Vector3.Lerp(transform.right, transform.up, Mathf.PingPong(kickAngle, 1));
    }

    private void KickUpdate()
    {
        kickCD.UpdateTimer(Time.deltaTime);
        if (Input.GetKeyDown(InputSettings.current.kick) && kickCD.isReady && !isSelectingkickAngle) isSelectingkickAngle = true;
        else if (Input.GetKeyDown(InputSettings.current.kick) && kickCD.isReady && isSelectingkickAngle) Kick(Mathf.PingPong(kickAngle, 1));
        if (isSelectingkickAngle) UpdateKickAngle();
    }

    private bool TryGetZadr(out Rigidbody2D zadrRB)
    {
        zadrRB = null;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, kickRange, zadr);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                var go = hit.collider.gameObject;
                if (go.HasComponent<ZadrCharacter>()) zadrRB = go.GetComponent<Rigidbody2D>();
            }
        }
        return zadrRB != null;
    }

    private void Kick(float angle)
    {
        if (TryGetZadr(out var zadrRB))
        {
            var kickDirection = Vector3.Lerp(transform.right, transform.up, angle);
            zadrRB.AddForce(kickDirection * kickForce);
            kickCD.Reset();
            isSelectingkickAngle = false;
            return;
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