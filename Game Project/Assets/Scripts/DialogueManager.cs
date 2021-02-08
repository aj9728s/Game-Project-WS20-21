using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public AudioSource paperSlideSound;

    [SerializeField]
    bool paperSound = false; 

    [SerializeField]
    private UnityEvent resetHint;

    [SerializeField]
    private GameObject player;

    private TextMeshProUGUI text;

    private TextMeshProUGUI nameChar;

    private Text buttonText;

    private Button button;

    private Image border;

    [SerializeField]
    private SODialogue dialogue;

    private bool dialogueEnabled = false;

    private int dialogueState = 0;


    void Start()
    {
        TextMeshProUGUI[] allText = GetComponentsInChildren<TextMeshProUGUI>();
        nameChar = allText[0];
        text = allText[1];
        border = GetComponentInChildren<Image>();
        buttonText = GetComponentInChildren<Text>();
        button = GetComponentInChildren<Button>();

    }

    // Update is called once per frame
    void Update()
    {

        if (dialogueEnabled)
        {
           

            nameChar.text = dialogue.nameChar[dialogueState];
            text.text = dialogue.dialogue[dialogueState];

            if (dialogueState == dialogue.dialogue.Length - 1)
                buttonText.text = "End >>";
            else
                buttonText.text = "Next >>";

            /*
            if (dialogueState == dialogue.dialogue.Length - 1 && Input.GetKey(KeyCode.E))
            {

                augmentDialogueState();
            }
            */
        }

    }

    public void augmentDialogueState()
    {
        Debug.Log("test");
        if (paperSound)
        {
            paperSlideSound.Play();
            
        }
        if (dialogueEnabled && dialogueState == dialogue.dialogue.Length - 1)
        {
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().freezeRotation = false;
          
            resetHint.Invoke();
            dialogueEnabled = false;
         

            
            border.enabled = false;
           



            nameChar.text = "";
            text.text = "";
            buttonText.text = "";

            dialogueState = 0;

            return;

        }

        dialogueState++;
    }

    public void activateDialogue()
    {
        if (paperSound)
        {
            paperSlideSound.Play();
        }

        dialogueEnabled = true;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().freezeRotation = true;
        
        dialogueState = 0;

        border.enabled = true;
        
    }
}
