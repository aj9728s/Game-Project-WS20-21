using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HintButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float hintTriggerDistance;

    [SerializeField]
    private SOHintManager hintManager;

    [SerializeField]
    private string buttonHint;

    [SerializeField]
    private UnityEvent triggerAfterAction;

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

            if (Input.GetKeyDown(KeyCode.F))
            {
                triggerAfterAction.Invoke();
                fPressed = true;
            }

        }
    }

    public void resetHint()
    {
        fPressed = false;
    }
}
