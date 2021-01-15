using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int damage;

    private Collider2D attackHitBox;

    private void Awake()
    {
        attackHitBox = GetComponent<Collider2D>();
    }

    public bool  Attack()
    {
        bool result = false;
        Collider2D[] colliders = new Collider2D[5];
        var collidersCount = attackHitBox.OverlapCollider(new ContactFilter2D() {useTriggers = true, layerMask = enemyLayer }, colliders);
        if (collidersCount > 0)
        {
            result = true;
            foreach (var collider in colliders)
            {
                collider.GetComponent<Enemy>()?.DealDamage(damage);
            }
        }

        return result;
    }
}
