using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;
    private Rigidbody bulletRB;
    private Transform bulletDir;
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
            // kill enemy
            Destroy(other.gameObject);
        }

        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject,4);
    }

    void OnCollisionEnter(Collision collision)
    {
     
     /*
        if (collision.gameObject.CompareTag("Player"))
        {
            Scene actualScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(actualScene.buildIndex);
        }
       */     
    }

   

}
