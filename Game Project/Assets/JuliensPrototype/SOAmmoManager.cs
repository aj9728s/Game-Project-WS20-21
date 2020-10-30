using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOAmmoManager : ScriptableObject
{
    public int ammoAmount;
    public List<int> weapons;
    public int selectedWeapon;

    void Awake()
    {
        
    }
    
}
