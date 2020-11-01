using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpen : MonoBehaviour
{
    [SerializeField]
    private int weaponNR = 0;

    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    private GameObject door;

    private float dist;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.GetComponentInParent<Transform>().position, door.transform.position);

        if (weaponManager.selectedWeapon == weaponNR && dist <= 2 && Input.GetButtonDown("Fire1"))
        {
            Destroy(door);
            weaponManager.selectedWeapon = weaponManager.weapons[0];
            weaponManager.weapons.Remove(weaponNR);
        }
    }
}
