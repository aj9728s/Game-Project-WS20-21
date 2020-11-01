using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Poison : MonoBehaviour
{
    [SerializeField]
    private int weaponNR = 4;

    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    private UnityEvent playerDied;

    // Update is called once per frame
    void Update()
    {
        int sWeapon = weaponManager.selectedWeapon;
       
        if (sWeapon == weaponNR && Input.GetButtonDown("Fire1"))
        {
            playerDied.Invoke();
        }
    }
}
