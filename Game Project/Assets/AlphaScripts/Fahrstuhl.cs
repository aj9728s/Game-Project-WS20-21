using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Fahrstuhl : MonoBehaviour
{
    [SerializeField]
    private float delayClosingDoor;

    [SerializeField]
    private float delayMovingElevator;

    [SerializeField]
    private float delayMovingCamera;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float timeSzeneSwap;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool zDirection_p;

    [SerializeField]
    private bool xDirection_p;

    [SerializeField]
    private bool zDirection_n;

    [SerializeField]
    private bool xDirection_n;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private UnityEvent ClosingDoor;

    private bool doorTriggered = false;

    private bool startMoving = false;

    private Vector3 offset;
    // Start is called before the first frame update
    [SerializeField]
    private SOWeaponManager weaponManager;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (doorTriggered)
            return;

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(closeDoor());
            doorTriggered = true;
        }
           
    }

    IEnumerator closeDoor()
    {
        yield return new WaitForSeconds(delayClosingDoor);
        ClosingDoor.Invoke();

        camera.GetComponent<TopDownFollowCamera>().TargetOffset.y += 5;
        yield return new WaitForSeconds(delayMovingElevator);

        offset = player.transform.position - transform.position;

        camera.GetComponent<TopDownFollowCamera>().enabled = false;

       
        startMoving = true;

        StartCoroutine(changeSzene());

    }

    IEnumerator changeSzene()
    {   
        
        yield return new WaitForSeconds(timeSzeneSwap);
        weaponManager.selectedWeapon = 0;
        weaponManager.weapons.Clear();
        weaponManager.weaponsName.Clear();
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            

        }
    }
    void LateUpdate()
    {
        if (startMoving)
        {

            if (zDirection_p)
                transform.position += transform.forward * Time.deltaTime * speed;
            else if (xDirection_p)
                transform.position += transform.right * Time.deltaTime * speed;
            else if (xDirection_n)
                transform.position -= transform.right * Time.deltaTime * speed;
            else if (zDirection_n)
                transform.position -= transform.forward * Time.deltaTime * speed;

            player.transform.position = transform.position + offset;

            
        }
    }





}
