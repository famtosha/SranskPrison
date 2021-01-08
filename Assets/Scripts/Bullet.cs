using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<IEnemy>();
        if (enemy != null) enemy.DealDamage(30);
        Destroy(gameObject);
    }
}
