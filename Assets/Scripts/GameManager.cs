﻿using System;
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

    public Stat food, branch, water, health, chickHealth, highScore;


    public Action OnDayStarts = delegate { };
    public Action OnDayEnds = delegate { };

    public Transform playerTransform;
    public Transform houseTransform;


    public enum DayState
    {
        day,night
    }

    public DayState dayState;

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

        highScore.currentValue = 0;
        chickHealth.currentValue = chickHealth.maxValue;

        NewDay();
    }


    private void NewDay()
    {
        dayState = DayState.day;
        ResetStats();
        OnDayStarts();
    }

    private void ResetStats()
    {
        food.currentValue = food.initialValue;
        water.currentValue = water.initialValue;
        branch.currentValue = branch.initialValue;
        health.currentValue = health.maxValue;
    }
    
    public void ChickenReturnsHome()
    {
        highScore.currentValue += setting.scorePointsperFood * food.currentValue;


        food.ResetValue();

        OnDayEnds();

        Invoke("NewDay", setting.secBetweenDays);

    }

}
