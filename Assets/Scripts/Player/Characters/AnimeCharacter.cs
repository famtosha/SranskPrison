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

    public float kickAngle = 0.5f;

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
        kickCD.UpdateTimer(Time.deltaTime);

        if (Input.GetKeyDown(InputSettings.current.kick) && kickCD.isReady) Kick();

        isHoldDuck = Input.GetKey(InputSettings.current.sneak);
        SitDown();
        StandUp();
    }

    private void SitDown()
    {
        if (!isDuck && isHoldDuck) isDuck = true;
    }

    private void Kick()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, kickRange, zadr);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.TryGetComponent(out ZadrCharacter zadr))
                {
                    var zadrRB = zadr.gameObject.GetComponent<Rigidbody2D>();
                    var kickDirection = Vector3.Lerp(transform.right, transform.up, kickAngle);
                    zadrRB.AddForce(kickDirection * kickForce);
                    kickCD.Reset();
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