using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float hintTriggerDistance;

    [SerializeField]
    private SOHintManager hintManager;

    [SerializeField]
    private UnityEvent dialogueTrigger;

    [SerializeField]
    private UnityEvent OtherTrigger;

    [SerializeField]
    private string buttonHint;

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
                fPressed = true;
                dialogueTrigger.Invoke();
                OtherTrigger.Invoke();
            }

        }
    }

    public void resetHint()
    {
        fPressed = false;
    }

}
