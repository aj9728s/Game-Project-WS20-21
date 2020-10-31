using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandLayout : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager commandSO;

    void Update()
    {
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

    }
}