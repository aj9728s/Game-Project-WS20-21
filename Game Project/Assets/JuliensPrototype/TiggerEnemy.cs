using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerEnemies;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < triggerEnemies.transform.childCount - 1; i++)
            {
                triggerEnemies.transform.GetChild(i).transform.GetComponent<Light>().enabled = true;
                triggerEnemies.transform.GetChild(i).transform.GetComponent<MeshRenderer>().enabled = true;
                triggerEnemies.transform.GetChild(i).transform.GetComponents<BoxCollider>()[0].enabled = true;
                triggerEnemies.transform.GetChild(i).transform.GetComponents<BoxCollider>()[1].enabled = true;
                triggerEnemies.transform.GetChild(i).transform.GetComponent<Rigidbody>().isKinematic = true;

                triggerEnemies.transform.GetChild(i).transform.GetComponent<EnemyCube>().enableAttack();

            }
        }
    }
}
