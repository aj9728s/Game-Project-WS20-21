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
    private AudioSource shoot;

    private bool shootPerm = false;

    [SerializeField]
    private float timeBetweenShoot = 3;

    [SerializeField]
    private float shootingRange = 5;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float speed = 5;

    private float timeBetweenShootTmp;

    void Start()
    {
        timeBetweenShootTmp = timeBetweenShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > shootingRange)
        {
            Vector3 targetWaypoint = player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
        }

        if (shootPerm && timeBetweenShootTmp < 0)
        {
            Shootf();
            shoot.Play();
            timeBetweenShootTmp = timeBetweenShoot;
        }

        else
        {
            Vector3 targetWaypoint = player.position;
            transform.LookAt(targetWaypoint);
            firePoint.LookAt(targetWaypoint);
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
