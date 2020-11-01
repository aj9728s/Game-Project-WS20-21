using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField]
    private UnityEvent enableAlarm;

    [SerializeField]
    private bool triggerForEnemies = false;

    [SerializeField]
    private GameObject triggerEnemies;

    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    public int weaponNR;

    [SerializeField]
    private GameObject textHintLayout;

    [SerializeField]
    private string weaponHint;


    //[SerializeField]
    //private GameObject GunLayout;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            weaponManager.textHint = weaponHint;
            weaponManager.timerText = 4f;
            weaponManager.weapons.Add(weaponNR);
            weaponManager.selectedWeapon = weaponNR;

            //GunLayout.SetActive(true);
            enableAlarm.Invoke();

            if (triggerForEnemies)
            {
                for (int i = 0; i < triggerEnemies.transform.childCount - 1; i++)
                {
                    triggerEnemies.transform.GetChild(i).transform.GetComponent<EnemyCube>().enableAttack();

                }
            }
            

            Destroy(gameObject, 2);
        }

    }
              
}
