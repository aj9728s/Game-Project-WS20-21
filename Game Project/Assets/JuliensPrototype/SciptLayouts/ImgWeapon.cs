using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImgWeapon : MonoBehaviour
{

    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private SOAmmoManager ammoManager;

    // Update is called once per frame
    void Update()
    {
        if (ammoManager.selectedWeapon == 0)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            GetComponent<Image>().sprite = null;
        }

        else if (ammoManager.selectedWeapon == 1)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[0];
        }//pistol

        else if (ammoManager.selectedWeapon == 2)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[1];
        } // flashlight

        else if (ammoManager.selectedWeapon == 3)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[2];
        } // key

        else if (ammoManager.selectedWeapon == 4)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[3];
        } // poison

        else if (ammoManager.selectedWeapon == 5)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            GetComponent<Image>().sprite = images[4];
        } // knife
    }
}
