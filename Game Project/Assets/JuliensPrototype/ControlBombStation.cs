using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlBombStation : MonoBehaviour
{

    [SerializeField]
    private SOAmmoManager command;

    [SerializeField]
    private GameObject securityCamera;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject ceiling;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private UnityEvent stopPlayerMov;

    [SerializeField]
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 2)
        {
            command.command = "F";
            command.timer2 = 0.1f;

            if (Input.GetKey(KeyCode.F))
            {
               
                stopPlayerMov.Invoke();
                securityCamera.GetComponent<Camera>().enabled = true;
                mainCamera.GetComponent<Camera>().enabled = false;
                bomb.GetComponent<BombMovement>().enabled = true;
                Destroy(ceiling);

            }
        }

    }
}
