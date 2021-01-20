using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class KnifingEnemy : MonoBehaviour
{
    //[SerializeField]
    //private NavMeshAgent navMesh;

    [SerializeField]
    private AudioSource taser;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float killingDistance;

    [SerializeField]
    private UnityEvent playerDead;

    private bool playerDeadBool = false;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private UnityEvent lightningPlayer;

    [SerializeField]
    private float timeUntilDeathScreen = 1;

    private bool startKnifing = false;

    void FixedUpdate()
    {
        if(startKnifing && !playerDeadBool)
        {
            Vector3 targetWaypoint = player.position;
            transform.LookAt(targetWaypoint);
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            //navMesh.SetDestination(targetWaypoint);
            if (Vector3.Distance(transform.position, player.position) < killingDistance)
            {
                Debug.Log(Vector3.Distance(transform.position, player.position));
                
                taser.Play();
                lightningPlayer.Invoke();
                playerDeadBool = true;
                StartCoroutine(DeathMenu());
            }
        }
       
    }

    IEnumerator DeathMenu()
    {
        yield return new WaitForSeconds(timeUntilDeathScreen);
        playerDead.Invoke();
    }

    public void enableKnifing()
    {
        startKnifing = true;
    }
}
