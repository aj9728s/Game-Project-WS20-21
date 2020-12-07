using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fahrstuhl : MonoBehaviour
{
    [SerializeField]
    private float timeClosingDoor;

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

    // Start is called before the first frame update
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
        yield return new WaitForSeconds(timeClosingDoor);
        // ClosingDoor.Invoke();
        // deactivating Player Movement
        player.GetComponent<PlayerMovement>().enabled = false;
        float yt = player.transform.position.y;
        player.transform.SetParent(transform);
        
        startMoving = true;
        StartCoroutine(changeSzene());

    }

    IEnumerator changeSzene()
    {
        yield return new WaitForSeconds(timeSzeneSwap);
        player.transform.SetParent(null);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
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
        }
    }



  
}
