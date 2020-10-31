using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombMovement : MonoBehaviour
{

    [SerializeField]
    private int movSpeed;

    [SerializeField]
    private SOAmmoManager command;

    [SerializeField]
    private UnityEvent startPlayerMov;

    [SerializeField]
    private GameObject mainCamera;

    private bool canMove = true;


    [SerializeField]
    private GameObject bombCamera;

    void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = bombCamera.GetComponent<Camera>().WorldToScreenPoint(transform.position);

        Vector3 dir = mousePos - playerPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        // ----------------------------------------------------------------------------------------------------------------------------------
        // Player Movement 
        // ----------------------------------------------------------------------------------------------------------------------------------

        Vector3 impulse = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            impulse = new Vector3(bombCamera.transform.forward.x, 0, bombCamera.transform.forward.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            impulse = new Vector3(-bombCamera.transform.forward.x, 0, -bombCamera.transform.forward.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            impulse = new Vector3(-bombCamera.transform.right.x, 0, -bombCamera.transform.right.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            impulse = new Vector3(bombCamera.transform.right.x, 0, bombCamera.transform.right.z);
        }

        impulse.Normalize();
        impulse *= movSpeed;
        this.GetComponent<Rigidbody>().velocity = impulse;

        if (Input.GetKey(KeyCode.E))
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            startPlayerMov.Invoke();
            bombCamera.GetComponent<Camera>().enabled = false;
            canMove = false;
        }

        this.GetComponent<Rigidbody>().velocity = impulse;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyableWall"))
        {
            Destroy(other.gameObject);
            transform.GetChild(0).GetComponent<Light>().enabled = false;
            GetComponent<Light>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            

        }

    }
}