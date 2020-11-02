using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PressStationChat : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private UnityEvent noDeadByWall;

    [SerializeField]
    private GameObject exitDoor;

    [SerializeField]
    private SOAmmoManager command;

    [SerializeField]
    private GameObject You;

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private string solutionID;

    [SerializeField]
    private GameObject canvasChat;

    private TextMeshProUGUI EnemyText;

    private TMP_InputField YouInput;

    private int counter = 0;

    private float timer = 0;

    private bool canvasState = false;

    private string input;
 
    void Start()
    {
        EnemyText = Enemy.GetComponent<TextMeshProUGUI>();
        YouInput = You.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= 2)
        {
            command.command = "F";
            command.timerCommand = 0.1f;

            if (Input.GetKeyDown(KeyCode.F))
            {
                canvasState = true;
                canvasChat.SetActive(true);
                player.GetComponent<Rigidbody>().isKinematic = true;
                YouInput.Select();
                YouInput.ActivateInputField();

            }

            if (timer < 0)
            {
                if (counter == 1)
                    EnemyText.text = "Boah ne Kevin... Nicht schon wieder. DU SOLLST DOCH IMMER DEINEN CHIP BEI DIR HABEN!!!";

                if (counter == 2)
                    EnemyText.text = "Naja... Machen wir es auf der alten Art und Weise... Gib mir deine ID und ich schalte den Alarm aus";

                if (counter == 3)
                    EnemyText.text = "Alter, hast du deine eigene ID auch noch vergessen???";

                if (counter == 4)
                    EnemyText.text = "Kevin ... Du solltest dich langsam mal beeilen";

                if (counter == 5)
                    EnemyText.text = "Bist du es überhaupt Kevin???";

                if (counter == 6)
                    EnemyText.text = "Der Name sagt ja alles";

                if (counter > 6)
                    EnemyText.text = "...";


                if (counter == 99)
                    EnemyText.text = "Oh man... Grüße meine Grußmutter von mir";

                if (counter == 100)
                {

                    canvasState = false;
                
                 
                }


                if (counter == 101)
                {

                    canvasState = false;
                
                }

                if(!canvasState && (counter == 100 || counter == 101))
                {
                    exitDoor.SetActive(false);
                   
                    canvasChat.SetActive(false);
                    player.GetComponent<Rigidbody>().isKinematic = false;

                }
            }

            else
            {
                timer -= Time.deltaTime;
            }

        }

        if (canvasState && Input.GetKeyDown(KeyCode.Return))
        {
            EnemyText.text = "";
            input  = YouInput.text;

            counter++;

            if (input.Contains(solutionID) && counter < 2)
            {
                EnemyText.text = "Ahaaaa... Du hast aus der Vergangenheit gelernt. Guter junge";
                counter = 101;
                timer = 2;
           
            }

            else if (input.Contains(solutionID))
            {
                EnemyText.text = "So, hab den Alarm ausgeschaltet... Beim nächsten mal lass ich dich aber verrecken";
                counter = 100;
                timer = 2;
              
            }



            YouInput.text = "";
            YouInput.Select();
            YouInput.ActivateInputField();
            timer = 1;
          
            

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PressWall"))
        {
            counter = 99;
              

        }
    }
}
