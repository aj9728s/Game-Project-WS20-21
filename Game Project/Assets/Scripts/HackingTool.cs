using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class HackingTool : MonoBehaviour
{

    [SerializeField]
    private AudioSource hackingSound;

    [SerializeField]
    private AudioSource stopHackingSound;

    [SerializeField]
    private UnityEvent togglePlayerMov;

    [SerializeField]
    private int weaponNR;

    [SerializeField]
    private GameObject[] hackableObjectsInSzene;

    private int hackingCharges;

    [SerializeField]
    private SOWeaponManager weaponManager;

    [SerializeField]
    private float hackableRange = 4f;

    private LineRenderer lineRenderer;

    [SerializeField]
    private float lineWidth = 0.05f;

    [SerializeField]
    private UnityEvent hackingCamera;

    [SerializeField]
    private SOHintManager hintManager;

    [SerializeField]
    private string buttonHint;

    private string tag;

    private bool inHackingRange = false;

    private bool isHacking = false;

    private int sWeapon;


    void Start()
    {
     
    }

    void Update()
    {

        hackingCharges = weaponManager.hackingCharges;
        sWeapon = weaponManager.selectedWeapon;

        if (sWeapon == weaponNR)
        {
            GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
            GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
        }

        else
        {
            GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
            GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
        }

        if (!isHacking && hackingCharges != 0 && Input.GetKeyDown(KeyCode.F) && sWeapon == weaponNR && inHackingRange)
        {
            togglePlayerMov.Invoke();
            hackingSound.Play();
            weaponManager.hackingCharges = weaponManager.hackingCharges - 1;

            if (tag == "SecurityCamera")
                hackingCamera.Invoke();

            isHacking = true;
        }

        else if (isHacking && Input.GetKeyDown(KeyCode.F))
        {
            togglePlayerMov.Invoke();
            stopHackingSound.Play();

            if (tag == "SecurityCamera")
                hackingCamera.Invoke();

            isHacking = false;
        }

        StartCoroutine(lineRendererCoroutine());
    }

    IEnumerator lineRendererCoroutine()
    {
        
        for (int i = 0; i < hackableObjectsInSzene.Length; i++)
        {
            lineRenderer = hackableObjectsInSzene[i].GetComponentInChildren<LineRenderer>();
            
            if (Vector3.Distance(hackableObjectsInSzene[i].transform.position, transform.position) < hackableRange)
            {
                if(sWeapon == weaponNR && hackingCharges != 0)
                {
                    hintManager.command = buttonHint;
                    hintManager.timerCommand = 0.1f;
                }
               

                inHackingRange = true;
                tag = hackableObjectsInSzene[i].tag;
                lineRenderer.SetPosition(0, lineRenderer.gameObject.transform.position);
                lineRenderer.SetPosition(1, transform.position);
                lineRenderer.SetWidth(lineWidth, lineWidth);
            }

            else
            {
                inHackingRange = false;
                tag = "";
                lineRenderer.SetPosition(0, lineRenderer.gameObject.transform.position);
                lineRenderer.SetPosition(1, lineRenderer.gameObject.transform.position);
            }
        }
        
        yield return null;


    }

}
