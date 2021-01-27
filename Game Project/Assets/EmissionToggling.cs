using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionToggling : MonoBehaviour
{
    private bool toggle = true;

    [SerializeField]
    private float frequenz = 0;

    private float timer = 0;

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > frequenz)
        {
            timer = 0;
            if (toggle)
                this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

            else
                this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);

            toggle = !toggle;
        }
    }


}