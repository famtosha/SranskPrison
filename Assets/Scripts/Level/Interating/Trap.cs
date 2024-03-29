﻿using UnityEngine;

public class Trap : MonoBehaviour, IInteraction
{
    public OpenRequire openType => OpenRequire.Closed;
    public int trapDamage = 4;
    private SpriteRenderer sr;

    private bool _isActive = true;
    public bool isActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            ChangeState(_isActive);
        }
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void ChangeState(bool state)
    {
        if (state)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.green;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isActive) collision.gameObject.GetComponent<IDamagable>().DealDamage(trapDamage);
    }

    public void HideInfo() { }
    public void ShowInfo() { }
    public bool UseByCharacter(UseAction use) { return false; }

    public bool UseByAnotherObject()
    {
        isActive = !isActive;
        return true;
    }
}