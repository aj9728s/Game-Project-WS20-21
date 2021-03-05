using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOLvLManager4 : MonoBehaviour
{
    [SerializeField]
    private SOLvLManager4 lvLManager4;

    [SerializeField]
    private SOWeaponManager weaponManager;

   
    public void HitFinishReset()
    {
        weaponManager.ammoAmount = 0;
        weaponManager.batteryLevel = 4;
        weaponManager.weapons.Clear();
        weaponManager.selectedWeapon = 0;
  
    }
}
