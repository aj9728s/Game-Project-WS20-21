using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    private bool withTrigger;

    [SerializeField]
    private bool withDistanceTrigger;

    [SerializeField]
    private float hintTriggerDistance;

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

    [SerializeField]
    private string weaponHint;

    private bool pickedUP = false;

    //[SerializeField]
    //private GameObject GunLayout;

    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            if (weapon && withTrigger)
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

    void Update() {
        if (weapon && withDistanceTrigger){
       
           if( Vector3.Distance(this.transform.position, player.transform.position) <= hintTriggerDistance && !pickedUP){
                triggeredDistance();

           }
        }
    }

    private void triggeredDistance()
    {
        pickedUP = true;
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
