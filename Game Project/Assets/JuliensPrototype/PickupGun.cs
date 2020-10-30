using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField]
    private UnityEvent enableShooting;

    [SerializeField]
    private GameObject triggerEnemies;

    //[SerializeField]
    //private GameObject GunLayout;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enableShooting.Invoke();
            //GunLayout.SetActive(true);

            for (int i = 0; i < triggerEnemies.transform.childCount - 1; i++)
            {
                triggerEnemies.transform.GetChild(i).transform.GetComponent<EnemyCube>().enableAttack();

            }

            Destroy(gameObject, 2);
        }
    }
}
