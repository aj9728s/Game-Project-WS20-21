using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBullet : MonoBehaviour
{

    [SerializeField]
    private int ammoNumber;

    [SerializeField]
    private SOAmmoManager ammoManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ammoManager.ammoAmount += ammoNumber;
            Destroy(gameObject, 0.5f);
        }
    }
}
