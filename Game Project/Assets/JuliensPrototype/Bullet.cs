using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;
    public Rigidbody bulletRB;
    public Transform bulletDir;
    private Vector3 _velocity;
    private float bulletForce = 20f;

    void Start()
    {
        bulletRB = this.GetComponent<Rigidbody>();
        bulletDir = this.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemie"))
        {
            Destroy(other.gameObject);
        }

        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject,4);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Mirror"))
            ReflectProjectile(bulletRB, collision.contacts[0].normal);

        if (collision.gameObject.CompareTag("Player"))
        {
            Scene actualScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(actualScene.buildIndex);
        }
            
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        _velocity = Vector3.Reflect(bulletDir.forward, reflectVector);
        bulletRB.velocity = _velocity * bulletForce;
    }

}
