using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintTextCanvas : MonoBehaviour
{
    [SerializeField]
    private SOHintManager textHint;

    void Update()
    {

        if (textHint.textHintPrio == "")
        {   
            this.GetComponentInChildren<TextMeshProUGUI>().text = textHint.textHint;

            if (textHint.timerText > 0)
            {
                textHint.timerText -= Time.deltaTime;
            }

            else
            {
                textHint.textHint = "";

            }



        }

        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = textHint.textHintPrio;

            if (textHint.timerText > 0)
            {
                textHint.timerText -= Time.deltaTime;
            }

            else
            {
                textHint.textHintPrio = "";

            }
        }

    }

}
