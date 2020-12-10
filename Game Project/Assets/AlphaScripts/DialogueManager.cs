using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent resetHint;

    [SerializeField]
    private GameObject player;

    private TextMeshProUGUI text;

    private TextMeshProUGUI nameChar;

    private Text buttonText;

    private Button button;

    private Image[] border;

    [SerializeField]
    private SODialogue dialogue;

    private bool dialogueEnabled = false;

    private int dialogueState = 0;


    void Start()
    {
        TextMeshProUGUI[] allText = GetComponentsInChildren<TextMeshProUGUI>();
        nameChar = allText[0];
        text = allText[1];
        border = GetComponentsInChildren<Image>();
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
                buttonText.text = "Continue >>";


            if (dialogueState == dialogue.dialogue.Length - 1 && Input.GetKey(KeyCode.E))
            {

                augmentDialogueState();
            }

        }

    }

    public void augmentDialogueState()
    {
       
        if (dialogueEnabled && dialogueState == dialogue.dialogue.Length - 1)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            resetHint.Invoke();
            dialogueEnabled = false;
         

            for (int i = 0; i < border.Length; i++)
            {
                border[i].enabled = false;
            }

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

        dialogueEnabled = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        dialogueState = 0;
        

        for (int i = 0; i < border.Length; i++)
        {
            border[i].enabled = true;
        }

    }
}
