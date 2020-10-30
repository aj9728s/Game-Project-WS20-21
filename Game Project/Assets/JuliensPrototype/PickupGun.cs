using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField]
    private UnityEvent enableAlarm;

    [SerializeField]
    private GameObject triggerEnemies;

    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    private int weaponNR;

    //[SerializeField]
    //private GameObject GunLayout;

    void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player"))
        {
            weaponManager.weapons.Add(weaponNR);
            weaponManager.selectedWeapon = weaponNR;

            //GunLayout.SetActive(true);
            enableAlarm.Invoke();

            for (int i = 0; i < triggerEnemies.transform.childCount - 1; i++)
            {
                triggerEnemies.transform.GetChild(i).transform.GetComponent<EnemyCube>().enableAttack();

            }

            Destroy(gameObject, 2);
        }
    }
}
