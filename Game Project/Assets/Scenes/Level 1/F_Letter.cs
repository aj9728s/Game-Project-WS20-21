using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class F_Letter : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private string weaponHint;

    [SerializeField]
    private int weaponNR;

    [SerializeField]
    private SOHintManager command;

    [SerializeField]
    private UnityEvent dialogueTriggerlvl1;


    private bool fPressed = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 5)
        {
            if (!fPressed)
            {
                command.command = "F";
                command.timerCommand = 0.1f;
            }
            
            if (Input.GetKey(KeyCode.F))
            {
                fPressed = true;
                dialogueTriggerlvl1.Invoke();
            }

        }
    }

    public void endDialogue()
    {
        fPressed = false;
           

    }
   
}
