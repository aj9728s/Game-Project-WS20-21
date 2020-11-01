using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    [SerializeField]
    private Vector3 mov2Position;

    private bool canMove = false;

    void Update()
    {
        if (canMove)
        {
            GetComponent<Rigidbody>().velocity = mov2Position;
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InvWall"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            canMove = false;
        }
          

    }

    public void moveEnable()
    {
        GetComponent<Light>().color = Color.green;
        canMove = true;

    }

}
