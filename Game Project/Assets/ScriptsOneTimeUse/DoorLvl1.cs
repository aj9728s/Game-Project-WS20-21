using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorLvl1 : MonoBehaviour
{
    [SerializeField]
    private AudioClip knock;

    [SerializeField]
    private AudioClip explosion;

    [SerializeField]
    private AudioClip tinnitus;

    [SerializeField]
    private Transform CameraPosition;

    [SerializeField]
    private float timeSzeneSwap;

    [SerializeField]
    private Image panel;

    private bool explosionBool = false;

    void Update()
    {
        if (explosionBool)
        {
            panel.enabled = true;
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.01f);
        }
            
    }

    public void enableHint()
    {
        this.gameObject.GetComponent<HintButtonTrigger>().enabled = true;
    }

    public void gotKnocked()
    {
        AudioSource.PlayClipAtPoint(knock, CameraPosition.position, 2f);
        
        StartCoroutine(changeSzene());
    }

    IEnumerator changeSzene()
    {
        yield return new WaitForSeconds(timeSzeneSwap);
        AudioSource.PlayClipAtPoint(explosion, CameraPosition.position, 4f);
        yield return new WaitForSeconds(1);
        AudioSource.PlayClipAtPoint(tinnitus, CameraPosition.position, 4f);
        explosionBool = true;



        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
