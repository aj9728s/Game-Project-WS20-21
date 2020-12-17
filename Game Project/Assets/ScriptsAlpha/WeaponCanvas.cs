using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponCanvas : MonoBehaviour
{

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private SOWeaponManager weaponManager;

    // Update is called once per frame
    void Update()
    {
        if (weaponManager.selectedWeapon == 0)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            GetComponent<Image>().sprite = null;
        }

        else if (weaponManager.selectedWeapon == 1)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[0];
        }//pistol

        else if (weaponManager.selectedWeapon == 2)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[1];
        } // flashlight

        else if (weaponManager.selectedWeapon == 3)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[2];
        } // key

        else if (weaponManager.selectedWeapon == 4)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[3];
        } // poison

        else if (weaponManager.selectedWeapon == 5)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[4];
        } // knife
    }
}
