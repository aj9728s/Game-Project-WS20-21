using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private bool pressed = false;

    [SerializeField]
    private UnityEvent groundMov;

    [SerializeField]
    private UnityEvent doorOpen;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!pressed)
        {
            this.GetComponent<Light>().color = Color.green;
            doorOpen.Invoke();
            groundMov.Invoke();
            pressed = true;
        }
        
    }
}
