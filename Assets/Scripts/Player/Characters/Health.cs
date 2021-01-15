using UnityEngine;

public class Health
{
    public static event HealthChanged HealthCanged;
    private Character character;

    private int _health;
    public int health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health < 1) PlayerDie();
            HealthCanged?.Invoke(character.playerID, _health);
        }
    }

    public void PlayerDie()
    {
        Debug.LogError("player dead x_x");
    }

    public void DealDamage(int hearts)
    {
        health -= hearts;
    }

    public void Heal(int hearts)
    {
        health += health;
    }

    public Health(Character character, int health)
    {
        this.character = character;
        this.health = health;
    }
}
