using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorLvl1 : MonoBehaviour
{
    [SerializeField]
    private AudioSource knock;

    [SerializeField]
    private AudioSource explosion;

    [SerializeField]
    private AudioSource tinnitus;

    [SerializeField]
    private SOLvLManager lvLManager;

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
        knock.Play();
        
        StartCoroutine(changeSzene());
    }

    IEnumerator changeSzene()
    {
        lvLManager.absolviertesLVL = 1;
        yield return new WaitForSeconds(timeSzeneSwap);
        explosion.Play();
        yield return new WaitForSeconds(1);
        tinnitus.Play();
        explosionBool = true;



        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
