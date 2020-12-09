using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;

   public static bool PlayerIsDead = false;

   public GameObject deathScreenUI;

    // Update is called once per frame
    
    public void QuitGame()
    {
        Application.Quit();
    }
   public void Death(){
        deathScreenUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;

    }
    public void Restart(){
        deathScreenUI.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
        GameIsPaused=false;
        SceneManager.LoadScene("TestLightroom1",LoadSceneMode.Single);
    }

}
