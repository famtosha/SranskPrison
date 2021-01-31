using UnityEngine;

public class Lightning : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamagable character))
        {
            character.DealDamage(damage);
        }
        Destroy(gameObject);
    }
}
