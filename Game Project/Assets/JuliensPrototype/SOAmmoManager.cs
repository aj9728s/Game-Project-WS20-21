using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOAmmoManager : ScriptableObject
{
    public int ammoAmount;
    public int batteryLevel;
    public List<int> weapons;
    public int selectedWeapon;
    public string command;
    public string commandPrior;
    public string textHint;
    public string textHintPrio;
    public float timerText = 0;
    public float timer2 = 0;

    void Awake()
    {
        
    }
    
}
