using UnityEngine;

[CreateAssetMenu(fileName = "New health pack", menuName = "Custom SO/Items/HealthPack")]
public class HealthPack : ConsumableItem
{
    public int healAmount;
    public override void Use(GameObject user)
    {
        var health = user.GetComponent<Character>().health;
        if(health < health.max)
        {
            health.health += healAmount;
        }
    }
}
