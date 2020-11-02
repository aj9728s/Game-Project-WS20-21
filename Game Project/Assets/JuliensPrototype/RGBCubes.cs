using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RGBCubes : MonoBehaviour
{
    [SerializeField]
    private bool red;

    [SerializeField]
    private bool blue;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool green;

    [SerializeField]
    private SOPuzzleManager puzzleManager;

    [SerializeField]
    private SOAmmoManager command;


    // Update is called once per frame
    void Update()
    {
     
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 2)
        {
            
            command.command = "F";
            command.timerCommand = 0.1f;

            if (Input.GetKeyDown(KeyCode.F))
            {
               
                if (red)
                {
                    puzzleManager.red = (puzzleManager.red + 1) % 10;
                    GetComponentInChildren<TextMeshPro>().text = puzzleManager.red.ToString();
                }


                if (green)
                {
                    puzzleManager.green = (puzzleManager.green + 1) % 10;
                    GetComponentInChildren<TextMeshPro>().text = puzzleManager.green.ToString();
                }


                if (blue)
                {
                    puzzleManager.blue = (puzzleManager.blue + 1) % 10;
                    GetComponentInChildren<TextMeshPro>().text = puzzleManager.blue.ToString();
                }

            }
        }
    }
}
