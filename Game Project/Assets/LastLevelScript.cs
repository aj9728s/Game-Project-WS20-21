using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelScript : MonoBehaviour
{
    [SerializeField]
    private SOLvLManager lvlManager;

    [SerializeField]
    private SOWeaponManager weaponManager;

    // Start is called before the first frame update
    public void trigger()
    {
        lvlManager.absolviertesLVL = 0;
        weaponManager.ammoAmount = 0;
        weaponManager.weapons.Clear();
        weaponManager.selectedWeapon = 0;
    }

   
}
