using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOWeaponManager : ScriptableObject
{
    public int ammoAmount;
    public int batteryLevel;
    public List<int> weapons;
    public List<string> weaponsName;
    public int selectedWeapon;
    public bool sneaking = false;

    void Awake()
    {

    }

}
