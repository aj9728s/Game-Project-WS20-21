using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField]
    private AudioSource doorSound;   

    [SerializeField]
    private bool openRight = false;

    [SerializeField]
    private bool openLeft = true;

    [SerializeField]
    private float rotateSpeed = 1f;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float angleRotation = 90.0f;

    private Vector3 destPos;
    private Vector3 closeDestPos;

    private int openDirection = -1;

    private bool block = false;

    [SerializeField]
    private bool oneEnemie = false;

    [SerializeField]
    private bool twoEnemies = false;

    private bool doorOpenState = false;

    [SerializeField]
    private float delayDoorCloseAuto = 2.0f;

    [SerializeField]
    private Transform enemyPosition1;

    [SerializeField]
    private Transform enemyPosition2;

    [SerializeField]
    private float triggerDistance = 8;

    //SpecialCase
    private int counter = 0;

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
        if (oneEnemie && Vector3.Distance(transform.parent.position, enemyPosition1.position) <= triggerDistance)
        {
            block = true;
            openDoorEnemy();
        }

  
        if (twoEnemies && Vector3.Distance(transform.parent.position, enemyPosition2.position) <= triggerDistance)
        {
            block = true;
            openDoorEnemy();
                
        }
        
    }


    public void toggleDoor()
    {
        if (!doorOpenState)
        {
            openDoor();
        }

        else
        {
            closeDoor();
        }

    }

    private void openDoorEnemy()
    {
        if (!doorOpenState)
        {
            openDoor();
            StartCoroutine(closeDoorEnemy());
        }
 
    }

    IEnumerator closeDoorEnemy()
    {
        yield return new WaitForSeconds(delayDoorCloseAuto);
        if(oneEnemie || twoEnemies)
            closeDoor();
        block = false;
    }

    public void openDoor()
    {
        doorSound.Play();
        StartCoroutine(RotateDoor());
        StartCoroutine(MoveDoor());
       
    }

    public void closeDoor()
    {
        doorSound.Play();
        StartCoroutine(CloseRotateDoor());
        StartCoroutine(CloseMoveDoor());
        
    }


    IEnumerator RotateDoor()
    {
        if(angleRotation < 0.0f)
        {
            
            while (transform.localEulerAngles.z - 360 > (angleRotation + 2f) || transform.localEulerAngles.z == 0)
            {
                
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, angleRotation), rotateSpeed * Time.deltaTime);
                yield return null;
            }

            transform.localRotation = Quaternion.Euler(0, 0, angleRotation);
            yield return null;
        }

        else
        {
           
            while (transform.localEulerAngles.z < (angleRotation - 2f)  || transform.localEulerAngles.z == 0)
            {
                
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, angleRotation), rotateSpeed * Time.deltaTime);
                yield return null;
            }

            transform.localRotation = Quaternion.Euler(0, 0, angleRotation);
            yield return null;
        }

    
    }

    IEnumerator CloseRotateDoor()
    {
        if (angleRotation < 0)
        {
            while (transform.localEulerAngles.z - 360 < -2)
            {
                
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, -angleRotation), rotateSpeed * Time.deltaTime);
                yield return null;
            }

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            yield return null;
        }

        else
        {
            while (transform.localEulerAngles.z > 2)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, -angleRotation), rotateSpeed * Time.deltaTime);
                yield return null;
            }

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            yield return null;
        }
    }

    IEnumerator MoveDoor()
    {
        doorOpenState = true;
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


    IEnumerator CloseMoveDoor()
    {
        doorOpenState = false;
        closeDestPos = transform.localPosition;
        closeDestPos.x += transform.localScale.x * -openDirection;

        if (openDirection == 1)
        {
            while (transform.localPosition.x > closeDestPos.x + 0.1)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, closeDestPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.localPosition = closeDestPos;
            yield return null;
        }
        else
        {
            while (transform.localPosition.x < closeDestPos.x - 0.1)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, closeDestPos, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.localPosition = closeDestPos;
            yield return null;
        }

        
    }

    public void disableOpenByEnemie()
    {
        oneEnemie = false;
        twoEnemies = false;
    }

    public void disableOpenAfterSomeEnemiesDead()
    {
        counter++;
        if(counter == 2)
        {
            disableOpenByEnemie();
        }
    }


}
