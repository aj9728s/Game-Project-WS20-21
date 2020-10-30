using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody EnemyRb;
    private Vector3 movement;

    [SerializeField]
    private UnityEvent lvlManagerPlayerDied;

    [SerializeField]
    private bool AttackEnabled;


    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //nemyRb.rotation = Quaternion.Euler(0, 0, angle); 
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        if (AttackEnabled)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector3 direction)
    {
        EnemyRb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lvlManagerPlayerDied.Invoke();
        }
    }

    public void enableAttack()
    {
        AttackEnabled = true;
    }
}
