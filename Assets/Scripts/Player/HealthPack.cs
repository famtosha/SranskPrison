using UnityEngine;

[CreateAssetMenu(fileName = "New health pack", menuName = "Custom SO/Items/HealthPack")]
public class HealthPack : ConsumableItem
{
    public int healAmount;
    public override void Use(GameObject user)
    {
        user.GetComponent<Character>().Heal(healAmount);
    }
}
