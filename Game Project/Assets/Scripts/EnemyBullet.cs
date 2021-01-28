using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private UnityEvent playerDead;

    private Rigidbody bulletRB;
    private Transform bulletDir;
    private Vector3 _velocity;
    private float bulletForce = 20f;

    [SerializeField]
    private AudioSource taser;

    void Start()
    {
        bulletRB = this.GetComponent<Rigidbody>();
        bulletDir = this.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 4);
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //playerDead.Invoke();
        }
    }



}
