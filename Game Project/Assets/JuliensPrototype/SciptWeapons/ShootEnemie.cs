using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemie : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField]
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    [SerializeField]
    private AudioClip shoot;

    private bool shootPerm = false;

    [SerializeField]
    private float timeBetweenShoot;

    private float timeBetweenShootTmp;

    void Start()
    {
        timeBetweenShootTmp = timeBetweenShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootPerm && timeBetweenShootTmp < 0)
        {
            Shootf();
            AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position, 1f);
            timeBetweenShootTmp = timeBetweenShoot;
        }

        else
        {
            timeBetweenShootTmp -= Time.deltaTime;
        }
        
    }

    void Shootf()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.VelocityChange);
    }

    public void enableShoot()
    {
        shootPerm = true;
    }
}
