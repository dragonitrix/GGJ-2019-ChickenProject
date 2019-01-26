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


    public Action OnNewDayStarts = delegate { };
    public Action OnchickenReturnsHome = delegate { };


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
        NewDay();
    }


    private void NewDay()
    {

        ResetStats();
        OnNewDayStarts();
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
        OnchickenReturnsHome();

    }

}
