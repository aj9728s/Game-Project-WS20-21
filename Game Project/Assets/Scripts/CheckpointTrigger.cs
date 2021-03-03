using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField]
    private SOLvl2Manager lvl2Manager;

    [SerializeField]
    private bool firstCheckpoint = false;

    [SerializeField]
    private bool secondCheckpoint = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (firstCheckpoint)
            {
                lvl2Manager.checkpoint1 = true;
                this.GetComponent<BoxCollider>().enabled = false;
            }

            if (secondCheckpoint)
            {
                lvl2Manager.checkpoint2 = true;
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
