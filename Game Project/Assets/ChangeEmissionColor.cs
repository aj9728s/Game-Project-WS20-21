using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    private Material myMat;

    [SerializeField]
    private bool open1 = false;

    [SerializeField]
    private bool open2 = false;

    [SerializeField]
    private SOCheckpointLvl3 lvl3Manager;

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
        myMat.SetColor("_EmissionColor", Color.green);

        if (open1)
        {
            lvl3Manager.terminal1 = true;
        }

        if (open2)
        {
            lvl3Manager.terminal2 = true;
        }

    }
}
