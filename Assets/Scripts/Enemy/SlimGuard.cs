using UnityEngine;

public class SlimGuard : Guard
{
    public CoolDown batCD = new CoolDown(3);
    public float batRange = 1;
    public int batDamage = 1;

    protected override void Update()
    {
        base.Update();
        batCD.UpdateTimer(Time.deltaTime);
        if (CanSeePlayer() && batCD.isReady) AttackWithBat();
    }

    private void AttackWithBat()
    {
        var hit = Physics2D.Raycast(transform.position, transform.right, batRange, playerLayer);
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