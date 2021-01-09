using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOOptionSettings : ScriptableObject
{

    public bool fullscreen = true;
    public float volumeBackground = 1;
    public float volumeSFX = 1;
    public int resolutionIndex = 0;

    void Awake()
    {

    }

}
