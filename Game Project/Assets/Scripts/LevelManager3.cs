using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager3 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent deathScreenTrigger;

    [SerializeField]
    private UnityEvent openDoor;

    [SerializeField]
    private SOWeaponManager hackingCharge;

    [SerializeField]
    private Fahrstuhl fahrstuhl;

    [SerializeField]
    private SOCheckpointLvl3 lvl3Manager;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private UnityEvent changeStationColor1;

    [SerializeField]
    private UnityEvent changeStationColor2;

    [SerializeField]
    private UnityEvent closeDoor;

    [SerializeField]
    private GameObject tag1;

    [SerializeField]
    private GameObject tag2;

    [SerializeField]
    private GameObject wall1;

    [SerializeField]
    private GameObject wall2;

    private bool finished = false;

    void Start()
    {

        Time.timeScale = 1;

        if (lvl3Manager.checkpoint2)
        {
            tag2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            //changeStationColor2.Invoke();
            fahrstuhl.openDoors = false;
            player.transform.position = new Vector3(-79.38f, 1.6f, -26.28f);
            tag2.tag = "lul";
            wall1.active = true;
            wall2.active = true;
            hackingCharge.hackingCharges = 0;
            lvl3Manager.terminal2 = true;
            
        }

        if (lvl3Manager.checkpoint1)
        {
            tag1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            tag1.tag = "lul";
            closeDoor.Invoke();
            fahrstuhl.openDoors = false;
            player.transform.position = new Vector3(-79.38f, 1.6f, -26.28f);
            hackingCharge.hackingCharges = 0;
            lvl3Manager.terminal1 = true;
        }

        else
        {

        }
    }

    void Update()
    {
        if (lvl3Manager.terminal1 && lvl3Manager.terminal2 && !finished)
        {
            openDoor.Invoke();
            finished = true;
        }
    }

    public void PlayerDied()
    {
        deathScreenTrigger.Invoke();

        // triggering Method for loosing ammunution maybe???

    }

    public void SetCheckpoint2()
    {
        lvl3Manager.checkpoint2 = true;
    }
}
