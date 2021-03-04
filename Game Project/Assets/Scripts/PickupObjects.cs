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
    private AudioSource PickUpSound;

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
    private int ammoAmount;

    [SerializeField]
    private bool hackAmmo;

    [SerializeField]
    private int hackAmount;

    [SerializeField]
    private UnityEvent triggerAfterPickup;

    [SerializeField]
    private SOWeaponManager weaponManager;

    [SerializeField]
    private float timerObjectDestroy;

    [SerializeField]
    public string weaponName;

    [SerializeField]
    public int weaponNR;

    [SerializeField]
    private string weaponHintDialogue;

    private bool triggered = false;

    [SerializeField]
    private SODialogue weaponDialogue;

    void Start()
    {
        if (checkIfAlreadyPickedUp())
        {
            this.gameObject.active = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (weapon && withTrigger)
            {
         
                PickUpSound.Play();
                weaponDialogue.dialogue[0] = weaponHintDialogue;
                weaponManager.weapons.Add(weaponNR);
                weaponManager.weaponsName.Add(weaponName);
                weaponManager.selectedWeapon = weaponNR;

                if(weaponNR == 3)
                {
                    weaponManager.hackingCharges = 1;

                }

                triggerAfterPickup.Invoke();
                Destroy(gameObject, timerObjectDestroy);

            }

            if (ammo && withTrigger)
            {
                

            }

        }

    }

    void Update() {

        if (weapon && withDistanceTrigger && !triggered)
        {
       
           if( Vector3.Distance(this.transform.position, player.transform.position) <= hintTriggerDistance && !checkIfAlreadyPickedUp())
           {
                PickUpSound.Play();
                triggeredDistance();
                triggered = true;

            }
        }

        if (ammo && withDistanceTrigger && !triggered)
        {

            if (Vector3.Distance(this.transform.position, player.transform.position) <= hintTriggerDistance)
            {
                PickUpSound.Play();
                triggeredDistance();
                triggered = true;

            }
        }

        if (hackAmmo && withDistanceTrigger && !triggered)
        {

            if (Vector3.Distance(this.transform.position, player.transform.position) <= hintTriggerDistance)
            {
                PickUpSound.Play();
                triggeredDistance();
                triggered = true;

            }
        }
    }

    private void triggeredDistance()
    {
        if (weapon)
        {
            weaponDialogue.dialogue[0] = weaponHintDialogue;
            weaponManager.weapons.Add(weaponNR);
            weaponManager.weaponsName.Add(weaponName);
            weaponManager.selectedWeapon = weaponNR;

            triggerAfterPickup.Invoke();
            Destroy(gameObject, timerObjectDestroy);
        }

        if (ammo)
        {
            weaponManager.ammoAmount = weaponManager.ammoAmount + ammoAmount;
            Destroy(gameObject, timerObjectDestroy);
        }

        if (hackAmmo)
        {
            weaponManager.hackingCharges = weaponManager.hackingCharges + hackAmount;
            Destroy(gameObject, timerObjectDestroy);
        }
    }

    private bool checkIfAlreadyPickedUp()
    {
        for (int i = 0; i < weaponManager.weapons.Count; i++)
        {
            if (weaponManager.weapons[i] == weaponNR)
            {
                return true;
                
            }
        }

        return false;
    }

}
