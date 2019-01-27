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


    private void Awake()
    {
        FindObjectOfType<CheckGameOver>().OnGameOver += StopMoving;
    }

    private void Update()
    {
        speed = baseSpeed + (baseSpeed * speedMultiplier * (waterStat.currentValue / waterStat.maxValue));


        waterStat.currentValue -= reducePerSec * Time.deltaTime;

        if(waterStat.currentValue < 0)
            waterStat.currentValue = 0;
    }

    private void StopMoving()
    {
        Paralyze(100f);
    }


    public void Paralyze(float time) {
        StartCoroutine(Paralyze(time, baseSpeed, speedMultiplier));
    }

    private IEnumerator Paralyze(float time, float spd, float spdMult) {
        float lerp = 0;

        while(lerp < time) {
            baseSpeed = Mathf.Lerp(0, spd, lerp / time);
            speedMultiplier = Mathf.Lerp(0, spdMult, lerp / time);
            lerp += Time.deltaTime;
            yield return null;
        }
        // to ensure speed will be at default value
        baseSpeed = spd;
        speedMultiplier = spdMult;
    }

}
