using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeCharacter : Character
{
    private bool _isDuck = false;
    public bool isDuck
    {
        get => _isDuck;
        set
        {
            _isDuck = value;
            if (_isDuck)
            {                
                move.moveSpeed = 5;
                transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
            }
            else
            {
                move.moveSpeed = 15;
                transform.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
            }
            print(transform.localScale);
        }
    }

    public override void SpectialUse()
    {
        isDuck = !isDuck;
    }
}
