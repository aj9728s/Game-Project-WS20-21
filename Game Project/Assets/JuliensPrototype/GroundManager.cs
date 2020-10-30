using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    [SerializeField]
    private Vector3 mov2Position;

    public void move()
    {
        this.GetComponent<Light>().color = Color.green;
        this.transform.position += mov2Position;


    }
}
