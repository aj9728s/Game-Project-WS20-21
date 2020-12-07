using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1 : MonoBehaviour
{
    // Flickering
    [SerializeField]
    private bool flackerLight;
    private Queue<float> smoothQueue;
    // lower values = sparks, higher = lantern / Range(1, 50)
    [SerializeField]
    private int smoothing = 5;
    private float lastSum = 0;
    [SerializeField]
    private float minIntensity = 0f;
    [SerializeField]
    private float maxIntensity = 1f;

    [SerializeField]
    private bool flackerLight2;
    [SerializeField]
    private float minTimer = 0f;
    [SerializeField]
    private float maxTimer = 1f;


    // Alarm
    [SerializeField]
    private bool alarmLight;
    [SerializeField]
    private float alarmFrequenzy = 0.5f;

    private Light lightObject;
    private float timer = 0;

    private float origIntensity;

    // Start is called before the first frame update
    void Start()
    {
        lightObject = GetComponent<Light>();
        origIntensity = lightObject.intensity;
        smoothQueue = new Queue<float>(smoothing);
    }

    // Update is called once per frame
    void Update()
    {
        if (alarmLight)
        {
            timer += Time.deltaTime;
            if (timer > alarmFrequenzy)
            {
                timer = 0;
                lightObject.enabled = !lightObject.enabled;

            }
        }

        if (flackerLight)
        {
            while (smoothQueue.Count >= smoothing)
            {
                lastSum -= smoothQueue.Dequeue();
            }

            // Generate random new item, calculate new average
            float newVal = Random.Range(minIntensity, maxIntensity);
            smoothQueue.Enqueue(newVal);
            lastSum += newVal;

            // Calculate new smoothed average
            lightObject.intensity = lastSum / (float)smoothQueue.Count;
        }

        if (flackerLight2)
        {
            float randomTimer = Random.Range(minTimer, maxTimer);
            timer += Time.deltaTime;


            if (timer > randomTimer)
            {
                timer = 0;
                lightObject.enabled = !lightObject.enabled;
            }
        }

    }

    public void enableAlarm()
    {
        alarmLight = true;
    }

    public void enableFlackering()
    {
       flackerLight = true;
    }

    public void enableFlackering2()
    {
        flackerLight2 = true;
    }

    public void stopAlarm()
    {
        alarmLight = false;
        lightObject.enabled = true;
    }

    public void stopFlackering()
    {
        flackerLight = false;
        lightObject.intensity = origIntensity;
    }

    public void stopFlackering2()
    {
        flackerLight2 = false;
        lightObject.enabled = true;

    }
}
