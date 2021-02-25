using UnityEngine;

public class NormalGuard : Guard
{
    public Timer batCD = new Timer(3);
    public float batRange = 1;
    public int batDamage = 1;
    public float jumpForce;

    private Timer jumpCD = new Timer(3);


    protected override void Update()
    {
        base.Update();
        batCD.UpdateTimer(Time.deltaTime);
        jumpCD.UpdateTimer(Time.deltaTime);
        if (MathHelper.RandomBool(0.01f)) Jump();
    }

    protected void Jump()
    {
        if (movement.IsGrounded() && jumpCD.isReady)
        {
            movement.rb.AddForce(Vector3.Lerp(transform.right, transform.up, 0.2f).normalized * jumpForce);
            jumpCD.Reset();
        }
    }

    public override void Attack()
    {
        base.Attack();
        AttackWithBat();
    }

    private void AttackWithBat()
    {
        if (batCD.isReady)
        {
            var hit = Physics2D.Raycast(transform.position, transform.right, batRange, movement.playerLayer);
            if (hit)
            {
                var character = hit.collider.gameObject;
                character.GetComponent<Character>().DealDamage(batDamage);
                if (character.TryGetComponent(out ZadrCharacter zadr))
                {
                    zadr.isSleeping = false;
                }
                batCD.Reset();
            }
        }
    }
}