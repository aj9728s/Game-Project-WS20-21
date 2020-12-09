﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GuardEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float waitTimeBetweenWayPoints = .3f;
    [SerializeField]
    private float turnSpeed = 90;
    [SerializeField]
    private Light spotlight;

    [SerializeField]
    private Color spotlightAfterDetection;

    private Color originalSpotlightColour;

    [SerializeField]
    private float viewDistance;
    [SerializeField]
    private LayerMask viewMask;

    private float viewAngle;
    [SerializeField]
    private Transform pathHolder;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private bool shootingEnemy = false;

    [SerializeField]
    private bool knifingEnemy = false;

    [SerializeField]
    private bool spottingDirectly = false;

    [SerializeField]
    private UnityEvent enableShoot;

    private bool spotted = false;
    private bool canSeeTrigger = false;


    private IEnumerator coroutine;

    void Start()
    {

    }

    void Update()
    {
        if (CanSeePlayer() || canSeeTrigger)
        {
            spotlight.color = spotlightAfterDetection;
            spotted = true;
            StopCoroutine(coroutine);
            if (shootingEnemy)
            {
                enableShoot.Invoke();
            }

        }

        /*
        else if (!CanSeePlayer() && !spotted)
        {
            spotlight.color = originalSpotlightColour;
        }
        */

        if (spotted)
        {
            Vector3 targetWaypoint = player.position;
            transform.LookAt(targetWaypoint);
            if (shootingEnemy && Vector3.Distance(transform.position, player.position) > 5)
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            else if (knifingEnemy)
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
        }
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {

                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTimeBetweenWayPoints);
                if (!spottingDirectly)
                    yield return StartCoroutine(TurnToFace(targetWaypoint));
                else if (!spottingDirectly && targetWaypointIndex != waypoints.Length)
                    yield return StartCoroutine(TurnToFace(targetWaypoint));

            }
            yield return null;

            if (spottingDirectly && targetWaypointIndex == 0)
                canSeeTrigger = true;

            if (spotted)
                break;

        }


    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

    public void TriggerEnemie()
    {
        coroutine = FollowPath(new Vector3[pathHolder.childCount]);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;

        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));

    }

}