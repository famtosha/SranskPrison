using UnityEngine;

[CreateAssetMenu(fileName = "New imba", menuName = "Custom SO/Items/Imba")]
public class Imba : ConsumableItem 
{
    public int imbaRange;
    public int imbaDamage;

    public override void Use(GameObject user)
    {
        foreach (var objectNear in Physics2D.OverlapCircleAll(user.transform.position, imbaRange))
        {
            if (objectNear.TryGetComponent(out Guard enemy))
            {
                enemy.DealDamage(imbaDamage);
            }
        }
    }
}