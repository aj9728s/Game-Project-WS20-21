using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private SOLvLManager lvLManager;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject credits;


    // Update is called once per frame
    void Update()
    {
        if(lvLManager.absolviertesLVL == 2)
        {
            credits.SetActive(true);
            mainMenu.SetActive(false);
            lvLManager.absolviertesLVL = 0;
        }
    }
}
