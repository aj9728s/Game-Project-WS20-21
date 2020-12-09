using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Flashlight : MonoBehaviour
{

    [SerializeField]
    private AudioClip click;

    [SerializeField]
    private int weaponNR = 0;

    [SerializeField]
    private SOAmmoManager weaponManager;

    private int batteryLvl;

    private bool flashlightStatus = true;

    private float tickTimer;

    [SerializeField]
    private float maxTime;

    void Start()
    {
        tickTimer = maxTime;
        weaponManager.batteryLevel = 4;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().enabled = flashlightStatus;
        batteryLvl = weaponManager.batteryLevel;
        int sWeapon = weaponManager.selectedWeapon;

        if (flashlightStatus)
        {
            tickTimer -= Time.deltaTime;

            if (tickTimer <= 0)
                weaponManager.batteryLevel = 0;
            else if (tickTimer <= (maxTime * 0.25f))
                weaponManager.batteryLevel = 1;
            else if (tickTimer <= (maxTime * 0.5f))
                weaponManager.batteryLevel = 2;
            else if (tickTimer <= (maxTime * 0.75f))
                weaponManager.batteryLevel = 3;


        }

        if (batteryLvl != 0 && Input.GetButtonDown("Fire1") && sWeapon == weaponNR)
        {
            AudioSource.PlayClipAtPoint(click, Camera.main.transform.position,2f);
            ChangeState();
        }

        if (batteryLvl == 0 || sWeapon != weaponNR)
        {
            flashlightStatus = false;
        }

        
    }

    void ChangeState()
    {
        flashlightStatus = !flashlightStatus;
    }
}
