using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class J_PlayerManagement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 3f;
    [SerializeField]
    private float sneakSpeed = 1.5f;
    [SerializeField]
    private float[] lightRange;
    [SerializeField]
    private double OutOfTheMapY = -5f;
    [SerializeField]
    private UnityEvent lvlManagerPlayerDied;

    private Rigidbody playerRig;
    private Light playerLight;
    private int lightRangeNumber;
    private int actualLightRange;
    private float timestamp = 0f;

    private bool canMove = true;

    [SerializeField]
    public Camera cam;

    [SerializeField]
    private SOAmmoManager weaponManager;

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        playerLight = GetComponent<Light>();
        actualLightRange = 0;
        lightRangeNumber = lightRange.Length;

    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        // ---------------------------------------------------------------------------------
        // Rotation of player with mouse
        // ---------------------------------------------------------------------------------

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = cam.WorldToScreenPoint(transform.position);

        Vector3 dir = mousePos - playerPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);

    }

    void FixedUpdate()
    {

        if (!canMove)
        {
            return;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        // Player Movement 
        // ----------------------------------------------------------------------------------------------------------------------------------

        /*
        Vector3 impulse = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            impulse = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            impulse = new Vector3(-cam.transform.forward.x, 0, -cam.transform.forward.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            impulse = new Vector3(-cam.transform.right.x, 0, -cam.transform.right.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            impulse = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
        }
        */
        Vector3 impulse = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        //Vector3 impulse = new Vector3(-Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));
      

        impulse.Normalize();

        if (weaponManager.sneaking)
        {
            impulse *= sneakSpeed;
        }

        else
        {
            impulse *= walkSpeed;
        }

        playerRig.velocity = impulse + new Vector3(0.0f, -1f, 0.0f); ;
        //this.GetComponent<CharacterController>().Move(impulse * 1/10);




        // ----------------------------------------------------------------------------------------------------------------------------------
        // Player Ligthning
        // ----------------------------------------------------------------------------------------------------------------------------------

        /*
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= timestamp)
        {
            if(actualLightRange == lightRangeNumber -1)
            {
                actualLightRange = -1;
            }
            actualLightRange += 1;
            playerLight.range = lightRange[actualLightRange];
            timestamp = Time.time + 0.5f;
        }
        */

        // ----------------------------------------------------------------------------------------------------------------------------------
        // Player FallDmg
        // ----------------------------------------------------------------------------------------------------------------------------------

        if (playerRig.position.y < OutOfTheMapY)
        {
            lvlManagerPlayerDied.Invoke();
        }
    }

    public void setCanMoveTrue()
    {
        canMove = true;
    }

    public void setCanMoveFalse()
    {
        canMove = false;
    }
}
