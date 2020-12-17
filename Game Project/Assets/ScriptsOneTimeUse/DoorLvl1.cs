using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLvl1 : MonoBehaviour
{
    [SerializeField]
    private AudioClip knock;

    [SerializeField]
    private AudioClip explosion;

    [SerializeField]
    private Transform CameraPosition;

    [SerializeField]
    private float timeSzeneSwap;

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
        AudioSource.PlayClipAtPoint(explosion, CameraPosition.position, 2f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
