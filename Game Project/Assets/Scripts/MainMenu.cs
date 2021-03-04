using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public SOLvLManager lvlManager;

    public void PlayGame(){
        SceneManager.LoadScene(lvlManager.absolviertesLVL + 1);
    }

    public void QuitGame(){
        Debug.Log ("Quit!");
        Application.Quit();
    }
}
