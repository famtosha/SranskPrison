using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeCharacter : Character
{
    public override int playerID  => 0; 

    private bool _isDuck = false;
    public bool isDuck
    {
        get => _isDuck;
        set
        {
            if (value == _isDuck) return;
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
        }
    }

    public override void CharacterUpdate()
    {
        base.CharacterUpdate();
        if (Input.GetKeyDown(KeyCode.K)) isDuck = true;
        if (Input.GetKeyUp(KeyCode.K)) isDuck = false;
        if (Input.GetKeyDown(KeyCode.J)) move.Jump();
    }
}
