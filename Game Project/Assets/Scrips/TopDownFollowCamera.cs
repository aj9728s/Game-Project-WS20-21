using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFollowCamera : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;

    // used in Fahrstuhl Script
    public Vector3 targetOffset;

    [SerializeField]
    private float moveSpeed = 2f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + targetOffset, moveSpeed * Time.fixedDeltaTime);
    }


    // static camera ------------------------

    /*
 
    private Vector3 camPos;

    void Start()
    {
        camOffset = transform.position - player.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camPos = player.position + targetOffset;
        transform.position = camPos;
    }

    */
}
