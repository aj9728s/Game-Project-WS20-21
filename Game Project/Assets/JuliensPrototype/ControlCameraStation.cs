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
            command.timerText = 0.1f;
            command.timer2 = 0.1f;
            command.textHint = "Dies ist eine Hacking Station mit welcher sich in Zukunf beliebige Dinge manipulieren lassen." +
                               "Du wirst diese immer mit der angebenen Taste bedienen können ";

            if (Input.GetKey(KeyCode.F))
            {
               
                for (int i = 0; i < triggerEnemies.transform.childCount; i++)
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
           
        }

    }

}
