﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stat : ScriptableObject
{
    public float maxValue, initialValue, currentValue;


    public void ResetValue()
    {
        currentValue = initialValue;
    }
}
