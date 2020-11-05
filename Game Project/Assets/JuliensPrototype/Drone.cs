using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float moveSpeed;

    private Vector3 direction;

    void Update()
    {

        // Vector3 mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;

        mousePos.Normalize();
        mousePos.y = 0;
        Debug.Log(mousePos);

        direction = mousePos - transform.position;
        direction.y = 0;
        //direction.Normalize();
        Debug.Log(direction);
        

        Vector3 myPos = transform.position;
        myPos.y = 0;
        //transform.position = Vector3.MoveTowards(myPos, mousePos ,moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition((transform.position + direction) * moveSpeed * Time.deltaTime);




    }

   

}
