using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpeed : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private float baseSpeed, speedMultiplier, reducePerSec;

    [SerializeField]
    private Stat waterStat;


    private void Update()
    {
        speed = baseSpeed + (baseSpeed * speedMultiplier * (waterStat.currentValue / waterStat.maxValue));


        waterStat.currentValue -= reducePerSec * Time.deltaTime;

        if(waterStat.currentValue < 0)
            waterStat.currentValue = 0;
    }

}
