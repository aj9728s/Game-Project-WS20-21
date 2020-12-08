﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private SOWeaponManager weaponManager;

    public void PlayerDied()
    {
        if(weaponManager.weapons.Count == 1)
        {
            deadAfterGettingFlashlight();
        }

        else
        {
            deadBeforeGettingFlashlight();
        }

    }

    private void deadBeforeGettingFlashlight()
    {
        // DEAD SZENE ???
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.buildIndex);

        weaponManager.ammoAmount = 0;
        weaponManager.batteryLevel = 4;
        weaponManager.weapons.Clear();
        weaponManager.selectedWeapon = 0;
        
    }

    private void deadAfterGettingFlashlight()
    {
        // DEAD SZENE ???
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.buildIndex);

        weaponManager.ammoAmount = 0;
        weaponManager.batteryLevel = 4;
        weaponManager.weapons.Clear();
        weaponManager.weapons.Add(1);
        weaponManager.selectedWeapon = 1;
      
    }
}
