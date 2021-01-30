using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletForce = 1000;

    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
    }
}