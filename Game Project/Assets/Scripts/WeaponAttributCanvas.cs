using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponAttributCanvas : MonoBehaviour
{
    [SerializeField]
    private SOWeaponManager weaponManager;

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private Image border;

    [SerializeField]
    private TextMeshProUGUI ammo;

    [SerializeField]
    private Image imageLeft;

    [SerializeField]
    private Image imageCenter;

    [SerializeField]
    private TextMeshProUGUI hackingCharge;

    void Update()
    {
        if (weaponManager.selectedWeapon == 0)
        {
            ammo.enabled = false;
            hackingCharge.enabled = false;
            imageLeft.color = new Color(0, 0, 0, 0);
            imageLeft.sprite = null;
            imageCenter.color = new Color(0, 0, 0, 0);
            imageCenter.sprite = null;
            border.enabled = false;
        }

        else if (weaponManager.selectedWeapon == 1)
        {
            ammo.enabled = false;
            hackingCharge.enabled = false;
            imageCenter.color = new Color(0, 0, 0, 0);
            imageCenter.sprite = null;
            border.enabled = true;

            imageLeft.color = new Color(255, 255, 255, 255);
            if (weaponManager.batteryLevel == 4)
                imageLeft.sprite = images[0];
            if (weaponManager.batteryLevel == 3)
                imageLeft.sprite = images[1];
            if (weaponManager.batteryLevel == 2)
                GetComponentInChildren<Image>().sprite = images[2];
            if (weaponManager.batteryLevel == 1)
                imageLeft.sprite = images[3];
            if (weaponManager.batteryLevel == 0)
                imageLeft.sprite = images[4];

        }

        else if (weaponManager.selectedWeapon == 2)
        {
            
            hackingCharge.enabled = false;
            imageCenter.color = new Color(0, 0, 0, 0);
            imageCenter.sprite = null;
            border.enabled = true;

            ammo.enabled = true;
            imageLeft.color = new Color(255, 255, 255, 255);
            ammo.text = weaponManager.ammoAmount.ToString();
            imageLeft.sprite = images[5];
        }

        else if (weaponManager.selectedWeapon == 3)
        {
            ammo.enabled = false;
            imageCenter.color = new Color(0, 0, 0, 0);
            imageCenter.sprite = null;
            imageLeft.color = new Color(255, 255, 255, 255);
            imageLeft.sprite = images[6];
            border.enabled = true;
            

            hackingCharge.enabled = true;
            hackingCharge.text = weaponManager.hackingCharges.ToString();


        }

        else if (weaponManager.selectedWeapon == 4)
        {
            border.enabled = true;
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = "inf";


        }

        else if (weaponManager.selectedWeapon == 5)
        {
            border.enabled = true;
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = "inf";


        }
    }
}
