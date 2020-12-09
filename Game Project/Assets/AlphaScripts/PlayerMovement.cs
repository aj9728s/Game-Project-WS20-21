using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
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
    private float gravity = -1;

    [SerializeField]
    public Camera cam;

    //[SerializeField]
    //private SOAmmoManager weaponManager;

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        playerLight = GetComponent<Light>();
        actualLightRange = 0;
        lightRangeNumber = lightRange.Length;

    }



    void FixedUpdate()
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

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);

        if (!canMove)
        {
            return;
        }

        // ----------------------------------------------------------------------------------------------------------------------------------
        // Player Movement 
        // ----------------------------------------------------------------------------------------------------------------------------------

     
        Vector3 impulse = new Vector3();

        impulse = new Vector3(-Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));


        impulse.Normalize();

        impulse *= walkSpeed;

        /*
        if (weaponManager.sneaking)
        {
            impulse *= sneakSpeed;
        }

        else
        {
            impulse *= walkSpeed;
        }
        */

        //playerRig.AddForce(impulse, ForceMode.VelocityChange);
        playerRig.velocity = impulse + new Vector3(0.0f, gravity, 0.0f); ;
        //this.GetComponent<CharacterController>().Move(impulse * 1/10);

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
