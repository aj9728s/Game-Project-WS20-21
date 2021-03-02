using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDropItem : MonoBehaviour
{
    
    public void dropWeapon()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<PickupObjects>().enabled = true;
        
    }
}
