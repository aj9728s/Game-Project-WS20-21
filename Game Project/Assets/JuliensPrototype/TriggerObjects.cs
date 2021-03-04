using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerObjects : MonoBehaviour
{
    [SerializeField]
    private UnityEvent enableObject;

    [SerializeField]
    private GameObject door;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            door.SetActive(true);
            enableObject.Invoke();
        }
            
    }
}
