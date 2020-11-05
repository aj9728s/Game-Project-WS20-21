using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePropeller : MonoBehaviour
{
    [SerializeField]
    private float propellerSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * propellerSpeed, Space.World);
    }
}
