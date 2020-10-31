using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextHintLayout : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager TextHint;

    private float timeRemaining = 200f ;

    public bool manuelHint = true;
    // Update is called once per frame
    void Update()
    {
        if (manuelHint && TextHint.textHintPrio == "")
            this.GetComponent<TextMeshProUGUI>().text = TextHint.textHint;
        if (manuelHint && TextHint.textHintPrio != "")
            this.GetComponent<TextMeshProUGUI>().text = TextHint.textHintPrio;

    }

    public void ShowHint()
    {
        while (timeRemaining > 0)
        {
            Debug.Log(timeRemaining);
            manuelHint = false;
            timeRemaining -= Time.deltaTime;
        }

        manuelHint = true;
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(3f);
    }

   
}
