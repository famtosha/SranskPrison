using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class Gun : MonoBehaviour
{
    public float bulletForce = 1000;
    public AudioClip shootSound;

    private AudioSource audioSource;
    private ParticleSystem particle;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
    }

    public void Shoot(GameObject bullet)
    {
        audioSource.PlayOneShot(shootSound);
        particle.Play();
        Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
    }
}