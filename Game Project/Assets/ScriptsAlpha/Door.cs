using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private AudioSource doorSound;   

    [SerializeField]
    private bool openRight = false;

    [SerializeField]
    private bool openLeft = true;

    [SerializeField]
    private float rotateSpeed = 0.000005f;

    [SerializeField]
    private float moveSpeed = 0.000005f;

    [SerializeField]
    private int angleRotation = 90;

    private Vector3 destPos;
    private Vector3 closeDestPos;

    private int openDirection = -1;

    void Start()
    {
        if (openRight)
            openDirection = 1;
        else
            openDirection = -1;

        destPos = transform.localPosition;
        destPos.x += transform.localScale.x * openDirection;
        

    }

    void Update()
    {
        // ZUM TESTEN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // StartCoroutine(RotateDoor());
        // StartCoroutine(MoveDoor());
    }
    
    public void openDoor()
    {
        doorSound.Play();
        StartCoroutine(RotateDoor());
        StartCoroutine(MoveDoor());
       
    }

    public void closeDoor()
    {
        StartCoroutine(CloseRotateDoor());
        StartCoroutine(CloseMoveDoor());
        
    }


    IEnumerator RotateDoor()
    {
        if(angleRotation < 0)
        {
            while (transform.localRotation.z > angleRotation)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, angleRotation * openDirection), rotateSpeed * Time.deltaTime);
                yield return null;
            }
        }

        else
        {
            while (transform.localRotation.z < angleRotation)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, angleRotation * openDirection), rotateSpeed * Time.deltaTime);
                yield return null;
            }
        }
        

        transform.localRotation = Quaternion.Euler(0, 0, angleRotation * openDirection);
        yield return null;
    }

    IEnumerator MoveDoor()
    {

        if (openDirection == 1)
        {
            while (transform.localPosition.x < destPos.x - 0.1)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, destPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (transform.localPosition.x > destPos.x + 0.1)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, destPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        transform.localPosition = destPos;
        yield return null;
    }

    
     
    IEnumerator CloseRotateDoor()
    {

        while (transform.rotation.z > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angleRotation * -openDirection), rotateSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, angleRotation * -openDirection);
        yield return null;
    }

    IEnumerator CloseMoveDoor()
    {
        closeDestPos = transform.position;
        closeDestPos.x += transform.localScale.x * -openDirection;

        if (openDirection == 1)
        {
            while (transform.position.x > closeDestPos.x)
            {
                transform.position = Vector3.Lerp(transform.position, closeDestPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (transform.position.x < closeDestPos.x)
            {
                transform.position = Vector3.Lerp(transform.position, closeDestPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        transform.position = closeDestPos;
        yield return null;
    }

    
}
