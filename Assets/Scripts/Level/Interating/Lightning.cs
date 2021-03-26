using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class Lightning : MonoBehaviour
{
    public int damage = 1;
    public AudioClip deathSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable character))
        {
            character.DealDamage(damage);
        }
        audioSource.loop = false;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1);
        Destroy(this);
    }
}
