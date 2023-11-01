using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, 1f / bulletSpeed);
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet_Movement bullet = Bullet.GetComponent<Bullet_Movement>();
        bullet.Initialize(bulletSpeed);
    }
}