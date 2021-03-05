using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOCheckpointLvl3 : ScriptableObject
{
    public bool checkpoint1 = false;
    public bool checkpoint2 = false;

    public bool terminal1 = false;
    public bool terminal2 = false;

    void Awake()
    {

    }

}
