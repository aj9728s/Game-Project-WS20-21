using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager command;

    [SerializeField]
    private UnityEvent startPlayerMov;

    [SerializeField]
    private GameObject mainCamera;

    private float speed = 100f;

    private bool rightClicked = false;

    void Update()
    {
        command.commandPrior = "E";
        command.timerText = 0.1f;
        command.timerCommand = 0.1f;
        command.textHintPrio = "Du kannst Kameras mit den Tasten A und S bewegen um dir" +
                               " einen Vorteil zu erschaffen. " +
                               " Übrigens... Pass immer auf deinen Rücken auf ";

        if (Input.GetKey(KeyCode.A))
        {   
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * -speed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            command.commandPrior = "";
            command.textHintPrio = "";
            mainCamera.GetComponent<Camera>().enabled = true;
            startPlayerMov.Invoke();
            GetComponentInChildren<Camera>().enabled = false;
            GetComponent<SecurityCamera>().enabled = false;
        }


    }

}
