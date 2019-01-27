using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpeed : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private float baseSpeed, boostedSpeed, reducePerSec;

    [SerializeField]
    private Stat waterStat;


    private void Awake()
    {
        FindObjectOfType<CheckGameOver>().OnGameOver += StopMoving;
    }

    private void Update()
    {
        if (waterStat.currentValue > 0)
        {
            waterStat.currentValue -= reducePerSec * Time.deltaTime;
            speed = boostedSpeed;
        }
        else
        {
            speed = baseSpeed;
        }


     
    }

    private void StopMoving()
    {
        Paralyze(100f);
    }


    public void Paralyze(float time)
    {
        StartCoroutine(Paralyze(time, baseSpeed, boostedSpeed));
    }

    private IEnumerator Paralyze(float time, float spd, float spdMult)
    {
        float lerp = 0;

        while (lerp < time)
        {
            baseSpeed = Mathf.Lerp(0, spd, lerp / time);
            boostedSpeed = Mathf.Lerp(0, spdMult, lerp / time);
            lerp += Time.deltaTime;
            yield return null;
        }
        // to ensure speed will be at default value
        baseSpeed = spd;
        boostedSpeed = spdMult;
    }

}
