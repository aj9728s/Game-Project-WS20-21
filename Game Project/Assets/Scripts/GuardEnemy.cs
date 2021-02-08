using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class GuardEnemy : MonoBehaviour
{
    
    public AudioSource enemymusic;
    public AudioSource defaultmusic;
    public AudioSource moving;
    public AudioSource scanning;
    public AudioSource chasing;

    [SerializeField]
    private UnityEvent triggerStart;

    [SerializeField]
    private float lookAtSpeed = 2;

    [SerializeField]
    private float pathSpeed = 5;

    [SerializeField]
    private float waitTimeAfterDetection = .3f;

    [SerializeField]
    private float waitTimeAfterRadiusDetection = 2f;
   
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
    private float detectionRadius;

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

    [SerializeField]
    private UnityEvent enableKnifing;

    [SerializeField]
    private AudioSource enemyDeadSound;

    [SerializeField]
    private UnityEvent trigerAfterDead;

    private bool spotted = false;
    private bool canSeeTrigger = false;

    private int direction = 1;

    bool followPath = false;

    Vector3 targetWaypoint;

    private IEnumerator coroutine;

    private bool lockMovement = true;

    private bool blockCanSeePlayerMethod = false;

    private bool detected = false;

    private bool detectedByRadius = false;

    private bool enemyDead = false;

    void Start()
    {
        triggerStart.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("BulletPlayer") && !enemyDead)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        enemyDead = true;
        enemyDeadSound.Play();

        enemymusic.Stop();
        chasing.Stop();
        defaultmusic.Pause();
        defaultmusic.Play();
        trigerAfterDead.Invoke();
        //animation
        GetComponent<KnifingEnemy>().enabled = false;
        GetComponent<GuardEnemy>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = true;
    }

    void FixedUpdate()
    {
        if (detected)
        {
            var rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * lookAtSpeed);
        }
           
            

        if (followPath && !lockMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, pathSpeed * Time.deltaTime);
           
        }
            

        if (CanSeePlayer() || canSeeTrigger)
        {
            moving.Stop();
            enemymusic.Play();
            defaultmusic.Stop();
            scanning.Play();

            spotlight.color = spotlightAfterDetection;
            spotted = true;
            StopCoroutine(coroutine);
            detected = true;
            StartCoroutine(Chasing());
        }
    }

    bool CanSeePlayer()
    {
        if (!blockCanSeePlayerMethod && Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            detectedByRadius = true;
            blockCanSeePlayerMethod = true;
            return true;

        }

        if (!blockCanSeePlayerMethod && Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    blockCanSeePlayerMethod = true;
                    return true;
                    
                }
            }
        }

        return false;
    }

    IEnumerator Chasing()
    {
        if(detectedByRadius)
            yield return new WaitForSeconds(waitTimeAfterRadiusDetection);

        else
            yield return new WaitForSeconds(waitTimeAfterDetection);

        detected = false;

        if (shootingEnemy)
        {
            enableShoot.Invoke();
        }

        else if (knifingEnemy)
        {
            enableKnifing.Invoke();
        }

        chasing.Play();

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
                        if (targetWaypointIndex == waypoints.Length -1 || targetWaypointIndex == 0)
                        {
                            direction = direction * -1;
                        }

                        targetWaypointIndex = targetWaypointIndex + (1 * direction);
                    }

                    else
                    {
                        targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                    }
                        
                    targetWaypoint = waypoints[targetWaypointIndex];
                    lockMovement = true;

                    moving.Pause();
                    yield return new WaitForSeconds(waitTimeBetweenWayPoints);
                    
                    yield return StartCoroutine(TurnToFace(targetWaypoint));
                    moving.UnPause();
                }

                else
                    canSeeTrigger = true;
              
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
        moving.Play();
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