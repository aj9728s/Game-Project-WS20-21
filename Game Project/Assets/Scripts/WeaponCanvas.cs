using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponCanvas : MonoBehaviour
{

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private Image border;

    [SerializeField]
    private SOWeaponManager weaponManager;

    // Update is called once per frame
    void Update()
    {
        if (weaponManager.selectedWeapon == 0)
        {
            border.enabled = false;
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            GetComponent<Image>().sprite = null;
        }

        else if (weaponManager.selectedWeapon == 1)
        {
            border.enabled = true;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[0];
        }//pistol

        else if (weaponManager.selectedWeapon == 2)
        {
            border.enabled = true;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[1];
        } // flashlight

        else if (weaponManager.selectedWeapon == 3)
        {
            border.enabled = true;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[2];
        } // key

        else if (weaponManager.selectedWeapon == 4)
        {
            border.enabled = true;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[3];
        } // poison

        else if (weaponManager.selectedWeapon == 5)
        {
            border.enabled = true;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[4];
        } // knife
    }
}
