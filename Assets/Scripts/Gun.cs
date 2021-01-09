using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
    }
}
