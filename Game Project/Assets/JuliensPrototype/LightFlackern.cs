using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlackern : MonoBehaviour
{
    [SerializeField]
    private int number;

    [SerializeField]
    private float timeBetweenBlink;

    [SerializeField]
    private float timePause;

    private float timeN;

    private float timeP;

    private int counter;

    private bool state = false;

    // Start is called before the first frame update
    void Start()
    {
        timeN = timeBetweenBlink;
        counter = number*2;
        timeP = timePause;
    }

    // Update is called once per frame
    void Update()
    {
        if (number != 0 && timeBetweenBlink > 0)
        {
            timeBetweenBlink -= Time.deltaTime;
            GetComponent<Light>().enabled = state;
        }

        else if (number != 0 && timeBetweenBlink <= 0)
        {

            state = !state;
            timeBetweenBlink = timeN;
            number--;
        }

        else
        {
            if(timePause > 0)
            {
                GetComponent<Light>().enabled = false;
                timePause -= Time.deltaTime;
            }


            else
            {
                number = counter;
                timePause = timeP;
            }
        }
    }
}
