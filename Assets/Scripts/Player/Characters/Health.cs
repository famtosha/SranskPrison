using System;
using UnityEngine;

[Serializable]
public class Health
{
    public event Action<int> HealthChanged;
    public event Action Death;

    public int min { get; private set; }

    [SerializeField]
    private int _max;
    public int max
    {
        get => _max;
        private set
        {
            _max = value;
        }
    }

    [SerializeField]
    private int _health;
    public int health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, min, max);
            HealthChanged?.Invoke(_health);
            if (_health == min) Death?.Invoke();
        }
    }

    public Health(int min, int max, int value)
    {
        this.min = min;
        this.max = max;
        health = value;
    }

    public static Health operator ++(Health health)
    {
        health.health++;
        return health;
    }

    public static bool operator >(Health firstOperand, int secondOperand)
    {
        return firstOperand.health > secondOperand;
    }

    public static bool operator <(Health firstOperand, int secondOperand)
    {
        return firstOperand.health < secondOperand;
    }
}