using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Szene2StartAnimation : MonoBehaviour
{
    [SerializeField]
    private AudioClip tinnitus;

    [SerializeField]
    private Transform CameraPosition;

    [SerializeField]
    private Image panel;

    void Start()
    {
        AudioSource.PlayClipAtPoint(tinnitus, CameraPosition.position, 4f);
    }

    void Update()
    {
        if (panel.color.a > 0)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - 0.01f);
            Debug.Log("wafwfwfafwawffwawffwa");
        }
            
        if (panel.color.a <= 0)
        {
            panel.enabled = false;
            
        }
           
    }
}
