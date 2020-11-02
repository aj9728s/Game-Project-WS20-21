using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBOpenDoor : MonoBehaviour
{

    [SerializeField]
    private SOPuzzleManager puzzleManager;
    [SerializeField]
    private Vector3 RGBSolution;

    // Update is called once per frame
    void Update()
    {
        if(puzzleManager.red == RGBSolution.x && puzzleManager.green == RGBSolution.y && puzzleManager.blue == RGBSolution.z)
        {
            Destroy(this.gameObject);
        }
    }
}
