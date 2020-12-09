using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintButtonCanvas : MonoBehaviour
{
    [SerializeField]
    private SOHintManager hintManager;

    private Image[] border;

    void Start()
    {
        border = GetComponentsInChildren<Image>();
    }

    void Update()
    {

        if (hintManager.commandPrior == "")
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = hintManager.command;

            for (int i = 0; i < border.Length; i++)
            {
                border[i].enabled = true;
            }

            if (hintManager.timerCommand > 0)
            {
                hintManager.timerCommand -= Time.deltaTime;
            }

            else
            {
                hintManager.command = "";

                for (int i = 0; i < border.Length; i++)
                {
                    border[i].enabled = false;
                }

            }



        }

        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = hintManager.commandPrior;
            for (int i = 0; i < border.Length; i++)
            {
                border[i].enabled = true;
            }

            if (hintManager.timerCommand > 0)
            {
                hintManager.timerCommand -= Time.deltaTime;
            }

            else
            {
                hintManager.commandPrior = "";

                for (int i = 0; i < border.Length; i++)
                {
                    border[i].enabled = false;
                }

            }
        }

    }

}