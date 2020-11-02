using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextHintLayout : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager TextHint;

    public float timeRemaining;

    // Update is called once per frame
    void Update()
    {
        
        if (TextHint.textHintPrio == "")
        {
            this.GetComponent<TextMeshProUGUI>().text = TextHint.textHint;

            if (TextHint.timerText > 0)
            {
                TextHint.timerText -= Time.deltaTime;
            }

            else
            {
                TextHint.textHint = "";
            
            }



        }

        else
        {
            this.GetComponent<TextMeshProUGUI>().text = TextHint.textHintPrio;

            if (TextHint.timerText > 0)
            {
                TextHint.timerText -= Time.deltaTime;
            }

            else
            {
                TextHint.textHintPrio = "";

            }
        }

    }
  
}
