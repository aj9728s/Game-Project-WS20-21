using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifingEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float killingDistance;

    [SerializeField]
    private UnityEvent playerDead;

    [SerializeField]
    private bool playerDeadBool = true;
    
    void Update()
    {

        if (Vector3.Distance(transform.position, player.position) < killingDistance && playerDeadBool)
        {

            playerDead.Invoke();
            playerDeadBool = false;
        }
    }
}
