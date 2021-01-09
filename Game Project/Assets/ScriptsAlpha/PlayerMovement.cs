using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public GameObject deathmusic;

    [SerializeField]
    private float walkSpeed = 4.5f;
    [SerializeField]
    private float sneakSpeed = 1.5f;
    [SerializeField]
    private double OutOfTheMapY = -5f;
    [SerializeField]
    private UnityEvent lvlManagerPlayerDied;

    private Rigidbody playerRig;
    private Light playerLight;
    private int lightRangeNumber;
    private int actualLightRange;
    private float timestamp = 0f;

    [SerializeField]
    public Camera cam;

    //[SerializeField]
    //private SOAmmoManager weaponManager;

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        // ---------------------------------------------------------------------------------
        // Rotation of player with mouse
        // ---------------------------------------------------------------------------------

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = cam.WorldToScreenPoint(transform.position);

        Vector3 dir = mousePos - playerPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
        

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

        impulse.y = playerRig.velocity.y;
        playerRig.velocity = impulse;

        // ----------------------------------------------------------------------------------------------------------------------------------
        // Player FallDmg
        // ----------------------------------------------------------------------------------------------------------------------------------

        if (playerRig.position.y < OutOfTheMapY)
        {
            deathmusic.SetActive(true);
            lvlManagerPlayerDied.Invoke();
        }
    }

}
