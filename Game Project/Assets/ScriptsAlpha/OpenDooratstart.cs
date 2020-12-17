using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDooratstart : MonoBehaviour
{

    public UnityEvent doorOpen;
    // Start is called before the first frame update
    void Start()
    {
       doorOpen.Invoke();
    }

}
