using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent triggerEnemie;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnemie.Invoke();
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
