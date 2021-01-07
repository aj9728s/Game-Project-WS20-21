using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class GuardEnemy : MonoBehaviour
{
    private audioManager theAM;
    public GameObject enemymusic;
    public GameObject defaultmusic;

    [SerializeField]
    private UnityEvent triggerStart;

    [SerializeField]
    private float pathSpeed = 5;

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
    private bool notCirclePath = false;

    [SerializeField]
    private UnityEvent enableShoot;

    private bool spotted = false;
    private bool canSeeTrigger = false;
    private int direction = 1;
    bool followPath = false;

    Vector3 targetWaypoint;

    private IEnumerator coroutine;
    private bool lockMovement = true;


    void Start()
    {
        triggerStart.Invoke();
    }

    void FixedUpdate()
    {
        if (followPath && !lockMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, pathSpeed * Time.deltaTime);
           
        }
            

        if (CanSeePlayer() || canSeeTrigger)
        {
            enemymusic.SetActive(true);
            defaultmusic.SetActive(false);
            spotlight.color = spotlightAfterDetection;
            spotted = true;
            StopCoroutine(coroutine);
            
            if (shootingEnemy)
            {
                enableShoot.Invoke();
            }

        }


        if (spotted)
        {
            Vector3 targetWaypoint = player.position;
            transform.LookAt(targetWaypoint);
            if (shootingEnemy && Vector3.Distance(transform.position, player.position) > 5)
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            else if (knifingEnemy)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
                

            }
               
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
        targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);
        followPath = true;
        lockMovement = false;

        while (true)
        {
            
            //transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, pathSpeed * Time.deltaTime);
            if ((transform.position.z >= targetWaypoint.z - 0.01 && transform.position.z <= targetWaypoint.z + 0.01) && (transform.position.x <= targetWaypoint.x + 0.01 && transform.position.x >= targetWaypoint.x - 0.01))
            {
                
                if (!spottingDirectly)
                {
                    

                    if (notCirclePath)
                    {
                        if (notCirclePath && targetWaypointIndex == waypoints.Length -1 || targetWaypointIndex == 0)
                        {
                            direction = direction * -1;
                        }

                        Debug.Log(targetWaypointIndex);
                        Debug.Log(waypoints.Length);
                        targetWaypointIndex = targetWaypointIndex + (1 * direction);
                    }

                    else
                    {
                        targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                    }
                        
                    targetWaypoint = waypoints[targetWaypointIndex];
                    lockMovement = true;
                    yield return new WaitForSeconds(waitTimeBetweenWayPoints);
                    if (!spottingDirectly)
                        yield return StartCoroutine(TurnToFace(targetWaypoint));
                    else if (!spottingDirectly && targetWaypointIndex != waypoints.Length)
                        yield return StartCoroutine(TurnToFace(targetWaypoint));
                }
                else
                {
                    
                    canSeeTrigger = true;
                    
                   
                }
                    


            }
            yield return null;
            
            if (spotted)
            {
                followPath = false;
                lockMovement = true;
                break;
            }
                

        }


    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        lookTarget.y = transform.position.y;
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }

        lockMovement = false;
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