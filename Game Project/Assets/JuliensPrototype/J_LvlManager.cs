using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class J_LvlManager : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager weaponManager;
    [SerializeField]
    private GameObject SecurityCamReset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayerDied()
    {
        ResetSecurityCam();
        ResetWeaponManager();
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.buildIndex);
        
    }

    public void ResetSecurityCam()
    {
        SecurityCamReset.GetComponent<SecurityCamera>().enabled = false;
        SecurityCamReset.GetComponentInChildren<Camera>().enabled = false;
    }

    public void ResetWeaponManager()
    {
        weaponManager.ammoAmount = 0;
        weaponManager.batteryLevel = 4;
        weaponManager.weapons.Clear();
        weaponManager.weapons.Add(2);
        weaponManager.selectedWeapon = 2;
        weaponManager.command = "";
        weaponManager.commandPrior = "";
        weaponManager.textHintPrio = "";
    }


}
