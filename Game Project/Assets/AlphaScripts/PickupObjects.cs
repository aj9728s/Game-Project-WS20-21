using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    [SerializeField]
    private bool weapon;

    [SerializeField]
    private bool ammo;

    [SerializeField]
    private UnityEvent triggerAfterPickup;

    [SerializeField]
    private SOWeaponManager weaponManager;

    [SerializeField]
    private SOHintManager hintManager;

    [SerializeField]
    private float durationHint;

    [SerializeField]
    private float timerObjectDestroy;

    [SerializeField]
    public string weaponName;

    [SerializeField]
    public int weaponNR;

    //[SerializeField]
    //private GameObject textHintLayout;

    [SerializeField]
    private string weaponHint;

    //[SerializeField]
    //private GameObject GunLayout;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (weapon)
            {
                hintManager.textHint = weaponHint;
                hintManager.timerText = durationHint;
                weaponManager.weapons.Add(weaponNR);
                weaponManager.weaponsName.Add(weaponName);
                weaponManager.selectedWeapon = weaponNR;

                //GunLayout.SetActive(true);
                triggerAfterPickup.Invoke();

                Destroy(gameObject, timerObjectDestroy);

            }
          
        }

    }

}
