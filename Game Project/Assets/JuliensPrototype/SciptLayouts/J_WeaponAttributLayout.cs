using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class J_WeaponAttributLayout : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager weaponManager;

    [SerializeField]
    private Sprite[] images;

    void Update()
    {
        if(weaponManager.selectedWeapon == 0)
        {
            GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<Image>().sprite = null;
        }

        else if (weaponManager.selectedWeapon == 1)
        {
            GetComponentInChildren<Image>().color = new Color(255, 255, 255, 255);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = weaponManager.ammoAmount.ToString();
            GetComponentInChildren<Image>().sprite = images[0];
        }

        else if (weaponManager.selectedWeapon == 2)
        {
            GetComponentInChildren<Image>().color = new Color(255, 255, 255, 255);
            GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            if(weaponManager.batteryLevel == 4)
                GetComponentInChildren<Image>().sprite = images[1];
            if (weaponManager.batteryLevel == 3)
                GetComponentInChildren<Image>().sprite = images[2];
            if (weaponManager.batteryLevel == 2)
                GetComponentInChildren<Image>().sprite = images[3];
            if (weaponManager.batteryLevel == 1)
                GetComponentInChildren<Image>().sprite = images[4];
            if (weaponManager.batteryLevel == 0)
                GetComponentInChildren<Image>().sprite = images[5];
        }

        else if (weaponManager.selectedWeapon == 3)
        {
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = "1";


        }

        else if (weaponManager.selectedWeapon == 4)
        {
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = "inf";


        }

        else if (weaponManager.selectedWeapon == 5)
        {
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = "inf";


        }
    }
}
