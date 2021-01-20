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

    void Update()
    {
        if (weaponManager.selectedWeapon == 0)
        {
            GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<Image>().sprite = null;
            border.enabled = false;
        }

        else if (weaponManager.selectedWeapon == 1)
        {
            GetComponentInChildren<Image>().color = new Color(255, 255, 255, 255);
            GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            border.enabled = true;
            if (weaponManager.batteryLevel == 4)
                GetComponentInChildren<Image>().sprite = images[0];
            if (weaponManager.batteryLevel == 3)
                GetComponentInChildren<Image>().sprite = images[1];
            if (weaponManager.batteryLevel == 2)
                GetComponentInChildren<Image>().sprite = images[2];
            if (weaponManager.batteryLevel == 1)
                GetComponentInChildren<Image>().sprite = images[3];
            if (weaponManager.batteryLevel == 0)
                GetComponentInChildren<Image>().sprite = images[4];

        }

        else if (weaponManager.selectedWeapon == 2)
        {
            border.enabled = true;
            GetComponentInChildren<Image>().color = new Color(255, 255, 255, 255);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = weaponManager.ammoAmount.ToString();
            GetComponentInChildren<Image>().sprite = images[6];
        }

        else if (weaponManager.selectedWeapon == 3)
        {
            border.enabled = true;
            GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().text = "1";


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
