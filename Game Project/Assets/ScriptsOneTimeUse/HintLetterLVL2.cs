using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HintLetterLVL2 : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float hintTriggerDistance;

    [SerializeField]
    private SOHintManager hintManager;

    [SerializeField]
    private SODialogue dialogueManager;

    [SerializeField]
    private UnityEvent dialogueTrigger;

    [SerializeField]
    private string buttonHint;

    [SerializeField]
    private string dialogueHint;


    private bool fPressed = false;

    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= hintTriggerDistance)
        {
            if (!fPressed)
            {
                hintManager.command = buttonHint;
                hintManager.timerCommand = 0.1f;
            }

            if (Input.GetKeyDown(KeyCode.F) && !fPressed)
            {
                dialogueManager.dialogue[0] = dialogueHint;
                fPressed = true;
                dialogueTrigger.Invoke();
                
            }

        }
    }

    public void resetHint()
    {
        fPressed = false;
    }

}
