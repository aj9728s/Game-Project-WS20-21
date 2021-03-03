using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Fahrstuhl : MonoBehaviour
{
    public AudioSource elevatorDoorSound;
    public AudioSource elevatorMoveSound;

    [SerializeField]
    private float delayClosingDoor;

    [SerializeField]
    private float delayCameraZoom;
    
    [SerializeField]
    private float delayMovingElevator;

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

    [SerializeField]
    private SOLvLManager lvlManager;

    public bool openDoors = false;

    private bool doorTriggered = false;

    private bool startMoving = false;

    private Vector3 offset;
    // Start is called before the first frame update
    [SerializeField]
    private SOWeaponManager weaponManager;
    void Start()
    {
        if (openDoors)
        {
            offset = player.transform.position - transform.position;
            camera.GetComponent<TopDownFollowCamera>().targetOffset.y += 8;
            elevatorMoveSound.Play();
            startMoving = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player" && !doorTriggered && !openDoors)
        {
            Debug.Log("test");
            doorTriggered = true;
            elevatorDoorSound.Play();
            StartCoroutine(closeDoor());
            
        }
      
        if (other.gameObject.tag == "ElevatorBlocker" && !doorTriggered)
        {
            elevatorMoveSound.Stop();
            doorTriggered = true;
            startMoving = false;
            elevatorDoorSound.Play();
            StartCoroutine(openDoor());

        }
    }

    IEnumerator closeDoor()
    {
        yield return new WaitForSeconds(delayClosingDoor);
        ClosingDoor.Invoke();

        camera.GetComponent<TopDownFollowCamera>().targetOffset.y += 5;
        yield return new WaitForSeconds(delayMovingElevator);

        offset = player.transform.position - transform.position;

        camera.GetComponent<TopDownFollowCamera>().enabled = false;

       
        startMoving = true;
        elevatorMoveSound.Play();

        StartCoroutine(changeSzene());

    }

    IEnumerator openDoor()
    {
        yield return new WaitForSeconds(delayClosingDoor);
        ClosingDoor.Invoke();
        yield return new WaitForSeconds(delayCameraZoom);
        camera.GetComponent<TopDownFollowCamera>().targetOffset.y -= 8;
    }

    IEnumerator changeSzene()
    {
        lvlManager.absolviertesLVL = 2;
        yield return new WaitForSeconds(timeSzeneSwap);
        weaponManager.selectedWeapon = 1;
        //weaponManager.weapons.Clear();
        //weaponManager.weaponsName.Clear();
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.buildIndex + 1);
    }

    void FixedUpdate()
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
