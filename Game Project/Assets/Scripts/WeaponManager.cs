using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private SOWeaponManager weaponManager;

    [SerializeField]
    public GameObject WeaponPickUpPrefab;

    [SerializeField]
    public Transform player;

    private int weaponNumber;

    private int counter = 0;

    // Update is called once per frame
    void Update()
    {
        weaponNumber = weaponManager.weapons.Count;

        if (weaponNumber > 1 && Input.GetKeyDown(KeyCode.Q))
        {
            resetValues();
            counter = ((counter + 1) % weaponNumber);
          
            weaponManager.selectedWeapon = weaponManager.weapons[counter];
            
           
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (weaponManager.weapons.Count != 0)
            {
                //dropWeapon();
            }
          
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
