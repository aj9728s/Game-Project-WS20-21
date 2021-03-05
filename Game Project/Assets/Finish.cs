using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    public GameObject finishScreenUI;


    public void HitFinish()
    {

        finishScreenUI.SetActive(true);
        Time.timeScale = 0f;


    }
    public void ZumHauptmenü()
    {

        finishScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
