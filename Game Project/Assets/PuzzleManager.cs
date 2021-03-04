using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent trigger;

    [SerializeField]
    private GameObject hint;

    [SerializeField]
    private GameObject light;

    [SerializeField]
    private GameObject hackCharge;

    [SerializeField]
    private SOPuzzleManager puzzleManager;

    private bool hintTrigger;


    // Update is called once per frame
    void Update()
    {
        if(puzzleManager.blue == 6 && puzzleManager.red == 8 && puzzleManager.green == 5)
        {
            trigger.Invoke();
            light.active = true;
            hackCharge.active = true;
            this.gameObject.active = false;
        }
    }

    IEnumerator TriggerHintCoroutine()
    {
        yield return new WaitForSeconds(60);
        hint.active = true;
    }

    public void TriggerHint()
    {
        StartCoroutine(TriggerHintCoroutine());
    }
}
