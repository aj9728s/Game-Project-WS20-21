using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDoorOpen : MonoBehaviour
{
    [SerializeField]
    private UnityEvent openTopDoorEnemy;

    [SerializeField]
    private UnityEvent openBottomDoorEnemy;

    [SerializeField]
    private Transform enemyPosition1;

    [SerializeField]
    private Transform enemyPosition2;

    [SerializeField]
    private float triggerDistance = 4;

    private bool block = false;

    [SerializeField]
    private bool twoEnemies = false;


    void Update()
    {
        if (!block)
        {
            if (Vector3.Distance(transform.position, enemyPosition1.position) <= triggerDistance)
            {
                block = true;
                openTopDoorEnemy.Invoke();
                openBottomDoorEnemy.Invoke();
            }

            if (twoEnemies)
            {
                if (Vector3.Distance(transform.position, enemyPosition2.position) <= triggerDistance)
                {
                    block = true;
                    openTopDoorEnemy.Invoke();
                    openBottomDoorEnemy.Invoke();
                }
            }
        }
    }

    public void SetBlockFalse()
    {
        block = false;
    }
}
