using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager weaponManager;

    private int weaponNumber;

    private int counter = 0;

    private float timestamp = 0f;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        weaponNumber = weaponManager.weapons.Count;

        if (weaponNumber != 0 && Input.GetKeyDown(KeyCode.Q) && Time.time >= timestamp)
        {
            weaponManager.selectedWeapon = weaponManager.weapons[counter];
            counter = (counter + 1) % weaponNumber;
            timestamp = Time.time + 0.5f;
        }
    }
}
