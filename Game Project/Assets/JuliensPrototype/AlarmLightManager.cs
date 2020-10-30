using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLightManager : MonoBehaviour
{
    private bool state = false;
    private bool alarmEnabled = false;

    private Light myLight;
    public float pulseSpeed = 0.5f; //seconds
    private float timer;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alarmEnabled)
        {
            timer += Time.deltaTime;
            if (timer > pulseSpeed)
            {
                timer = 0;
                myLight.enabled = !myLight.enabled;
            }
        }
    }

    public void enableAlarm()
    {
        alarmEnabled = true;
    }

}
