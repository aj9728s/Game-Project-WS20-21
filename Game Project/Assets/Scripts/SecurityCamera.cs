using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Audio;

public class SecurityCamera : MonoBehaviour
{
  
    [SerializeField]
    private AudioSource alarm;

    [SerializeField]
    private AudioSource movingCamera;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private float viewDistance;

    [SerializeField]
    private LayerMask viewMask;

    private float viewAngle;

    [SerializeField]
    private Light spotlight;

    [SerializeField]
    private UnityEvent triggerAfterDetected;


    private bool playerDetected = false;

    private bool isHacked = false;

    private float cameraMoveSpeed = 100f;

    private bool rightClicked = false;

    [SerializeField]
    private Transform player;

    private bool musicPlaying = true;


    void Start()
    {
        viewAngle = spotlight.spotAngle;
     
    }

    void Update()
    {
       
        if (CanSeePlayer())
        {
            alarm.Play();
            triggerAfterDetected.Invoke();
        }

        // Hints

        if (isHacked)
        {
          
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * -cameraMoveSpeed, Space.World);
                if (musicPlaying)
                {
                    movingCamera.Play();
                    musicPlaying = false;
                }
            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * cameraMoveSpeed, Space.World);
                if (musicPlaying)
                {
                    movingCamera.Play();
                    musicPlaying = false;
                }
            }

            else
            {
                movingCamera.Pause();
                musicPlaying = true;
            }

            
        }
    }

    private bool CanSeePlayer()
    {
        if (!playerDetected && Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
              
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    
                    playerDetected = true;
                    return true;
                    
                }
            }

            
        }

        return false;
    }

    public void toggleHacking()
    {
        isHacked = !isHacked;
        mainCamera.GetComponent<Camera>().enabled = !mainCamera.GetComponent<Camera>().enabled;
        GetComponentInChildren<Camera>().enabled = !GetComponentInChildren<Camera>().enabled;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
