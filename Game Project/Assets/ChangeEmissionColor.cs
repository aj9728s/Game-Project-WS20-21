using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    private Material myMat;

    [SerializeField]
    private float intensity = 1.5f;

    void Start()
    {
        myMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void turnToGreen()
    {
        myMat.SetColor("_EmissionColor", new Vector4(0, 255, 0, intensity));


    }
}
