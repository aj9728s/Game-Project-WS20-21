using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Szene2StartAnimation : MonoBehaviour
{
    [SerializeField]
    private AudioSource tinnitus;

    [SerializeField]
    private Image panel;

    void Start()
    {
        tinnitus.Play();
    }

    void Update()
    {
        if (panel.color.a > 0)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - 0.01f);        
        }
            
        if (panel.color.a <= 0)
        {
            //panel.enabled = false;
            tinnitus.volume = tinnitus.volume - 0.01f;

        }
           
    }
}
