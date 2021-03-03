using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
   public GameObject deathScreenUI;
 
    public void QuitGame()
    {
        Application.Quit();
    }
   public void Death(){

        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;


    }
    public void Restart(){

        deathScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl_2",LoadSceneMode.Single);
    }

}
