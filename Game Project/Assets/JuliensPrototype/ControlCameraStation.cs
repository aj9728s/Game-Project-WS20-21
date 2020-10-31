using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ControlCameraStation : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager command;

    [SerializeField]
    private GameObject triggerEnemies;

    [SerializeField]
    private GameObject securityCamera;

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

            if (Input.GetKey(KeyCode.F))
            {
                command.command = "";

                for (int i = 0; i < triggerEnemies.transform.childCount - 1; i++)
                {
                    triggerEnemies.transform.GetChild(i).transform.GetComponent<Light>().enabled = true;
                    triggerEnemies.transform.GetChild(i).transform.GetComponent<MeshRenderer>().enabled = true;
                    triggerEnemies.transform.GetChild(i).transform.GetComponent<BoxCollider>().enabled = true;

                    triggerEnemies.transform.GetChild(i).transform.GetComponent<EnemyCube>().enableAttack();

                }

                stopPlayerMov.Invoke();
                securityCamera.GetComponentInChildren<Camera>().enabled = true;
                securityCamera.GetComponent<SecurityCamera>().enabled = true;
                mainCamera.GetComponent<Camera>().enabled = false;

            }
        }

        else
        {
            command.command = "";
        }

    }
}
