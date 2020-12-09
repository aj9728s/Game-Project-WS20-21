using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class F_SOHintManager : ScriptableObject
{
    public string command;
    public string commandPrior;
    public string textHint;
    public string textHintPrio;
    public float timerText = 0;
    public float timerCommand = 0;

    void Awake()
    {

    }

}
