using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stat : ScriptableObject
{
    public float maxValue;
    public float currentValue;


    public void ResetValue()
    {
        currentValue = maxValue;
    }
}
