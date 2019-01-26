using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    private static GameManager instance;


    public Setting setting;


    public float lightValue = 1;
    float lightLerpSpeed = 5;

    [HideInInspector]
    public float currentDayTimer = 0;

    public Stat food, branch, water, health, chickHealth;


    public Action OnDayStarts = delegate { };
    public Action OnDayEnds = delegate { };
    public float score;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        // Set trap penalty (sec)
        setting.trapPenaltyInSec = setting.dayLengthInSec / 10f;
        NewDay();
    }


    private void NewDay()
    {
        ResetStats();
        OnDayStarts();
    }

    private void ResetStats()
    {
        food.currentValue = food.initialValue;
        water.currentValue = water.initialValue;
        branch.currentValue = branch.initialValue;
        health.currentValue = health.maxValue;
        chickHealth.currentValue = chickHealth.maxValue;
    }
    
    public void ChickenReturnsHome()
    {
        score += setting.scorePointsperFood * food.currentValue;
        food.ResetValue();

        OnDayEnds();

        Invoke("NewDay", setting.secBetweenDays);

    }

}
