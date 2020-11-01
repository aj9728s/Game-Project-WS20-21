using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private int[] weaponNr;

    [SerializeField]
    private SOAmmoManager weapons;

    [SerializeField]
    private UnityEvent playerDied;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < weaponNr.Length; i++)
        {
            if (other.CompareTag("Player") && weapons.weapons.Contains(weaponNr[i]))
                playerDied.Invoke();
        }
           

    }
}
