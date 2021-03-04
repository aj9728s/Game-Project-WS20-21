using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class LevelManager2 : MonoBehaviour
{

    [SerializeField]
    private UnityEvent deathScreenTrigger;

    [SerializeField]
    private Fahrstuhl fahrstuhl;

    [SerializeField]
    private SOLvl2Manager lvl2Manager;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        
        Time.timeScale = 1;
        
        if (lvl2Manager.checkpoint2 == true)
        {
            fahrstuhl.openDoors = false;
            player.transform.position = new Vector3(-58.04f,2.28f,163.07f);
        }

        else if(lvl2Manager.checkpoint1 == true)
        {
            fahrstuhl.openDoors = false;
            player.transform.position = new Vector3(-7.32f, 2.28f, 106.87f);
        }

        else
        {

        }
    }

    public void PlayerDied()
    {
        deathScreenTrigger.Invoke();

        // triggering Method for loosing ammunution maybe???

    }

    /*
    private void deadBeforeGettingFlashlight()
    {
        // DEAD SZENE ???
        //Scene actualScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(actualScene.buildIndex);

        weaponManager.ammoAmount = 0;
        weaponManager.batteryLevel = 4;
        weaponManager.weapons.Clear();
        weaponManager.selectedWeapon = 0;

    }

    private void deadAfterGettingFlashlight()
    {
        // DEAD SZENE ???
        //Scene actualScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(actualScene.buildIndex);

        weaponManager.ammoAmount = 0;
        weaponManager.batteryLevel = 4;
        weaponManager.weapons.Clear();
        weaponManager.weapons.Add(1);
        weaponManager.selectedWeapon = 1;

    }
    */
}
