using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;

    [SerializeField]
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    [SerializeField]
    private int weaponNR = 2;

    [SerializeField]
    private SOWeaponManager weaponManager;

    [SerializeField]
    private AudioSource shoot;

    [SerializeField]
    private AudioSource noAmmo;

    // Update is called once per frame
    void Update()
    {
        int sWeapon = weaponManager.selectedWeapon;
        int aWeapon = weaponManager.ammoAmount;

        if (sWeapon == weaponNR)
        {
            GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
            GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
        }

        else
        {
            GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
            GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
        }

        if (sWeapon == weaponNR && Input.GetButtonDown("Fire1") && aWeapon != 0)
        {
            Shootf();
            shoot.Play();
            weaponManager.ammoAmount -= 1;
        }

        else if(sWeapon == weaponNR && Input.GetButtonDown("Fire1") && aWeapon == 0)
        {
            noAmmo.Play();
        }
    }

    void Shootf()
    {
       
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.VelocityChange);
    }
}
