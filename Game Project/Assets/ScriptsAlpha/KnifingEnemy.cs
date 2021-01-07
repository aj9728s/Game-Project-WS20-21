using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifingEnemy : MonoBehaviour
{
    [SerializeField]
    private AudioClip taser;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float killingDistance;

    [SerializeField]
    private UnityEvent playerDead;

    [SerializeField]
    private bool playerDeadBool = true;

    [SerializeField]
    private Transform CameraPosition;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < killingDistance && playerDeadBool)
        {
            AudioSource.PlayClipAtPoint(taser, CameraPosition.position, 4f);
            playerDead.Invoke();
            playerDeadBool = false;
        }
    }
}
