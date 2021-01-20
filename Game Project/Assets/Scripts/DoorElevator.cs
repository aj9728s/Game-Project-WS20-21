using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorElevator : MonoBehaviour
{
    [SerializeField]
    private bool closeRight = false;

    [SerializeField]
    private bool closeLeft = true;

    [SerializeField]
    private float moveSpeed = 1f;

    private Vector3 destPos;
    private Vector3 closeDestPos;

    private int closeDirection = -1;

    private bool cD = false;

    private bool oD = false;

    void Start()
    {
        if (closeRight)
            closeDirection = 1;
        else
            closeDirection = -1;

        destPos = transform.localPosition;
        destPos.z += transform.localScale.x * closeDirection;


    }

    void Update()
    {
        if (cD)
            StartCoroutine(CloseDoor());

        else if(oD)
            StartCoroutine(OpenDoor());
    }

    public void openDoor()
    {
        oD = true;
    }

    public void closeDoor()
    {
        cD = true;
    }

    IEnumerator CloseDoor()
    {

        if (closeDirection == 1)
        {
            while (transform.localPosition.z < destPos.z)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, destPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (transform.localPosition.z > destPos.z)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, destPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        transform.localPosition = destPos;
        yield return null;
    }

    IEnumerator OpenDoor()
    {
        closeDestPos = transform.position;
        closeDestPos.x += transform.localScale.z * -closeDirection;

        if (closeDirection == 1)
        {
            while (transform.position.z > closeDestPos.z)
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
