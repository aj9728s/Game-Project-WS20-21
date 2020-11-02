using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBullet : MonoBehaviour
{

    [SerializeField]
    private int ammoNumber;

    [SerializeField]
    private SOAmmoManager ammoManager;

    [SerializeField]
    private AudioClip reload;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(reload, Camera.main.transform.position, 1f);
            ammoManager.ammoAmount += ammoNumber;
            Destroy(gameObject, 0.5f);
        }
    }
}
