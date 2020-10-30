using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField]
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private bool shootPerm = false;

    // Update is called once per frame
    void Update()
    {
        if (shootPerm && Input.GetButtonDown("Fire1"))
        {
            Shootf();
        }
    }

    void Shootf()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }

    public void EnableShoot()
    {
        shootPerm = true;
    }
}
