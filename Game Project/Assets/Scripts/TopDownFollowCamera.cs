using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFollowCamera : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;

    // used in Fahrstuhl Script
    public Vector3 targetOffset;

    public float OffsetInMoveXDirection;
    public float OffsetInMoveZDirection;
    public Vector2 OffsetInderSchraege;

    
    public float moveSpeed = 2f;

    [SerializeField]
    private float camSpeedAtBeginning = 12;

    private float tmpMoveSpeed;

    private Vector3 newOffset;

    private void Start()
    {
        tmpMoveSpeed = moveSpeed;
        moveSpeed = camSpeedAtBeginning;
        newOffset = targetOffset;
    }

    
    private void Update()
    {
        newOffset = targetOffset;

        /*
        if(transform.position.y <= player.position.y + newOffset.y + 0.5)
        {
            moveSpeed = tmpMoveSpeed;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            newOffset = targetOffset + new Vector3(-OffsetInderSchraege.x, 0, OffsetInderSchraege.y);
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            newOffset = targetOffset + new Vector3(-OffsetInderSchraege.x, 0, -OffsetInderSchraege.y);
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            newOffset = targetOffset + new Vector3(OffsetInderSchraege.x, 0, OffsetInderSchraege.y);
        }

        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            newOffset = targetOffset + new Vector3(OffsetInderSchraege.x, 0, -OffsetInderSchraege.y);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            newOffset = targetOffset + new Vector3(-OffsetInMoveXDirection, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            newOffset = targetOffset + new Vector3(0, 0, -OffsetInMoveZDirection);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            newOffset = targetOffset + new Vector3(OffsetInMoveXDirection, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            newOffset = targetOffset + new Vector3(0, 0, OffsetInMoveZDirection);
        }

        else
        {

        }
            //newOffset = targetOffset;
        */



    }

    
    private void FixedUpdate()
    {
        

        transform.position = Vector3.Lerp(transform.position, player.position + newOffset, moveSpeed * Time.fixedDeltaTime);
        
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
