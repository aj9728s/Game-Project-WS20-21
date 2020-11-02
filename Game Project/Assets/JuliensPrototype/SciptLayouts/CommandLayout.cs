using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandLayout : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager commandSO;

    private Image[] border;

    void Start()
    {
        border = GetComponentsInChildren<Image>();
    }

    void Update()
    {

        if (commandSO.commandPrior == "")
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = commandSO.command;

            for (int i = 0; i < border.Length; i++)
            {
                border[i].enabled = true;
            }

            if (commandSO.timerCommand > 0)
            {
                commandSO.timerCommand -= Time.deltaTime;
            }

            else
            {
                commandSO.command = "";

                for (int i = 0; i < border.Length; i++)
                {
                    border[i].enabled = false;
                }

            }



        }

        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = commandSO.commandPrior;
            for (int i = 0; i < border.Length; i++)
            {
                border[i].enabled = true;
            }

            if (commandSO.timerCommand > 0)
            {
                commandSO.timerCommand -= Time.deltaTime;
            }

            else
            {
                commandSO.commandPrior = "";

                for (int i = 0; i < border.Length; i++)
                {
                    border[i].enabled = false;
                }

            }
        }

    }


/*
        if (commandSO.command == "")
        {
          
            Image[] test = GetComponentsInChildren<Image>();

            for (int i = 0; i < test.Length; i++)
            {
                test[i].enabled = false;
            }

            this.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

        else
        {
            Image[] test = GetComponentsInChildren<Image>();

            for (int i = 0; i < test.Length; i++)
            {
                test[i].enabled = true;
            }

            if(commandSO.commandPrior == "")
                this.GetComponentInChildren<TextMeshProUGUI>().text = commandSO.command;
            else
                this.GetComponentInChildren<TextMeshProUGUI>().text = commandSO.commandPrior;
        }

 */
}