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
        Debug.Log("1");
        if (other.CompareTag("Player"))
        {
            Debug.Log("wrq");
            door.SetActive(true);
            enableObject.Invoke();
        }
            
    }
}
