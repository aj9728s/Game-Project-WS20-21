using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    private Vector3 mov2Position;

    [SerializeField]
    private float speed;

    [SerializeField]
    private UnityEvent playerDied;

    private bool canMove = false;
    private bool canDie = true;

    void Update()
    {
        if (canMove)
        {
            GetComponent<Rigidbody>().velocity = mov2Position * speed;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PressWall") && canDie)
        {
            playerDied.Invoke();
            canMove = false;
        }


    }

    public void changeMoveState()
    {
        canMove = !canMove;

    }

    public void disableDead()
    {
        canDie = false;

    }
}
