﻿using UnityEngine;

public class GeneratorTrap : MonoBehaviour
{
    public GameObject lightningPrefub;
    public float lightningSpeed;
    public Timer shootCD = new Timer(5);

    public void Update()
    {
        shootCD.UpdateTimer(Time.deltaTime);
        if (shootCD.isReady) Shoot();
    }

    public void Shoot()
    {
        var lightning = Instantiate(lightningPrefub, transform.position, Quaternion.identity);
        lightning.GetComponent<Rigidbody2D>().AddForce(transform.right * lightningSpeed);
        shootCD.Reset();
    }
}
