using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintButtonCanvas : MonoBehaviour
{
    [SerializeField]
    private SOHintManager hintManager;

    private Image border;

    void Start()
    {
        border = GetComponentInChildren<Image>();
    }

    void Update()
    {

        if (hintManager.commandPrior == "")
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = hintManager.command;

                border.enabled = true;

            if (hintManager.timerCommand > 0)
            {
                hintManager.timerCommand -= Time.deltaTime;
            }

            else
            {
                hintManager.command = "";

 
                border.enabled = false;
                

            }



        }

        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = hintManager.commandPrior;
         
                border.enabled = true;
     

            if (hintManager.timerCommand > 0)
            {
                hintManager.timerCommand -= Time.deltaTime;
            }

            else
            {
                hintManager.commandPrior = "";

              
                border.enabled = false;
                

            }
        }

    }

}