using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFollowCamera : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 TargetOffset;
    [SerializeField]
    private float MoveSpeed = 2f;

    private Transform _myTransform;

    private void Start()
    {
        _myTransform = transform;
    }

    public void SetTarget(Transform aTransform)
    {
        player = aTransform;
    }

    private void FixedUpdate()
    {
        if (player != null)
            _myTransform.position = Vector3.Lerp(_myTransform.position, player.position + TargetOffset, MoveSpeed * Time.fixedDeltaTime);
    }

    

    /*
    [SerializeField]
    Transform player;

    Vector3 camPos;
    Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - player.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camPos = player.position + camOffset;
        transform.position = camPos;
    }
    */
}
