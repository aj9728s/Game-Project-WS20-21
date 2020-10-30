using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class J_LvlManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayerDied()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.buildIndex);
    }


}
