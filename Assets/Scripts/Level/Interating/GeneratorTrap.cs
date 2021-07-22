using UnityEngine;

[RequireComponent(typeof(GeneratorTrap))]
public class GeneratorTrap : MonoBehaviour
{
    public GameObject lightningPrefub;
    public Transform lightOrigin;
    public float lightningSpeed;
    public Timer shootCD = new Timer(5);
    public AudioClip shootSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        shootCD.UpdateTimer(Time.deltaTime);
        if (shootCD.isReady) Shoot();
    }

    public void Shoot()
    {
        var lightning = Instantiate(lightningPrefub, lightOrigin.position, lightOrigin.rotation);
        lightning.GetComponent<Rigidbody2D>().AddForce(lightning.transform.right * lightningSpeed);
        shootCD.Reset();
        audioSource.PlayOneShot(shootSound);
    }
}
