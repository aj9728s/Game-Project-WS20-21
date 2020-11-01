using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    public GameObject WeaponPickUpPrefab;

    [SerializeField]
    public GameObject player;

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
            resetValues();
            weaponManager.selectedWeapon = weaponManager.weapons[counter];
            counter = (counter + 1) % weaponNumber;
            timestamp = Time.time + 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if(weaponManager.selectedWeapon != 2)
                dropWeapon();
        }
    }

    void dropWeapon()
    {
        int weaponNr = weaponManager.selectedWeapon;
        weaponManager.weapons.Remove(weaponManager.selectedWeapon);
        weaponManager.selectedWeapon = weaponManager.weapons[0];

        if (weaponManager.weapons.Count == 1)
            counter = 0;
        else
            counter = 1;

        GameObject WeaponPickUp = Instantiate(WeaponPickUpPrefab, player.transform.position + player.transform.right, player.transform.rotation);
        WeaponPickUp.GetComponent<PickupGun>().weaponNR = weaponNr;
    }

    void resetValues()
    {
        weaponManager.sneaking = false;
    }
}
