using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private int weaponNR = 5;

    [SerializeField]
    private SOAmmoManager weaponManager;

    // Update is called once per frame
    void Update()
    {
        int sWeapon = weaponManager.selectedWeapon;


        if (sWeapon == weaponNR)
        {
            weaponManager.sneaking = Input.GetKey(KeyCode.LeftShift);


            if (Input.GetButtonDown("Fire1"))
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<BoxCollider>().enabled = true;
            }

            else
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {

        int sWeapon = weaponManager.selectedWeapon;

        if (sWeapon == weaponNR && other.CompareTag("Enemie"))
        {
          
            Destroy(other.gameObject);
        }
    }

    
}
