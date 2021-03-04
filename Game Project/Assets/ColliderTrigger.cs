using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent trigger;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.Invoke();
            this.GetComponent<BoxCollider>().enabled = false;
            
        }
    }
}
