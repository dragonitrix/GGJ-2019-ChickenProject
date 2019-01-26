using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpeed : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private float baseSpeed, speedMultiplier;

    [SerializeField]
    private Stat waterStat;


    private void Update()
    {
        speed = baseSpeed + (baseSpeed * speedMultiplier * (waterStat.currentValue / waterStat.maxValue));
    }

}
