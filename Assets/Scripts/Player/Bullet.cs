using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable enemy))
        {
            enemy.DealDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}