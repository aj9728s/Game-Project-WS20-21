using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class J_DialogueManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent personDialogue1;

    [SerializeField]
    private UnityEvent getWeapon;

    private TextMeshProUGUI text;

    private TextMeshProUGUI nameChar;

    private Text buttonText;

    private Button button;

    private Image[] border;

    [SerializeField]
    private SODialogue dialogueLvl1;

    private bool dialogue1 = false;


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
      
        if (dialogue1)
        {
            nameChar.text = dialogueLvl1.nameChar[dialogueState];
            text.text = dialogueLvl1.dialogue[dialogueState];

            if (dialogueState == dialogueLvl1.dialogue.Length -1)
                buttonText.text = "End (E) >>";
            else
                buttonText.text = "Continue >>";


            if (dialogueState == dialogueLvl1.dialogue.Length - 1 && Input.GetKey(KeyCode.E))
            {
                augmentDialogueState();
            }

        }

    }

    public void augmentDialogueState()
    {
        if (dialogue1 && dialogueState == dialogueLvl1.dialogue.Length - 2)
        {
            getWeapon.Invoke();
        }

        if (dialogue1 && dialogueState == dialogueLvl1.dialogue.Length -1)
        {
            dialogue1 = false;
            button.enabled = false;

            for (int i = 0; i < border.Length; i++)
            {
                border[i].enabled = false;
            }

            nameChar.text = "";
            text.text = "";
            buttonText.text = "";

            dialogueState = 0;
            personDialogue1.Invoke();

            return;

        }

        dialogueState++;
    }

    public void activateDialogue1()
    {
        dialogue1 = true;
        dialogueState = 0;
        button.enabled = true;

        for (int i = 0; i < border.Length; i++)
        {
            border[i].enabled = true;
        }

    }
}
