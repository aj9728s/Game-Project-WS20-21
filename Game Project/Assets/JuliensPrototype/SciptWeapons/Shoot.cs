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
    private int weaponNR = 0;

    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    private AudioClip shoot;

    [SerializeField]
    private AudioClip noAmmo;

    // Update is called once per frame
    void Update()
    {
        int sWeapon = weaponManager.selectedWeapon;
        int aWeapon = weaponManager.ammoAmount;

        if (sWeapon == weaponNR && Input.GetButtonDown("Fire1") && aWeapon != 0)
        {
            Shootf();
            AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position, 1f);
            weaponManager.ammoAmount -= 1;
        }

        else if(sWeapon == weaponNR && Input.GetButtonDown("Fire1") && aWeapon == 0)
        {
            AudioSource.PlayClipAtPoint(noAmmo, Camera.main.transform.position, 2f);
        }
    }

    void Shootf()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.VelocityChange);
    }
}
