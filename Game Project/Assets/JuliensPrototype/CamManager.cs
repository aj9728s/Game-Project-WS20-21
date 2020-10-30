using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector3 camPos;
    Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        camPos = player.transform.position + camOffset;
        transform.position = camPos;
    }
}
