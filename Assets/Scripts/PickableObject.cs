using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Object
{
    [SerializeField]
    private Stat statToChange;

    public PickableObjectPool myPool;



    private void Awake()
    {
        GameManager.Instance.OnDayEnds += SelfDestruct;
    }


    protected override void Start()
    {
        base.Start();

                       if (myPool == null)
            Debug.Log("I should be spawned through OjectPool!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            statToChange.currentValue++;
            SelfDestruct();
        }
    }


    private void SelfDestruct()
    {
        myPool.AddToPool(this);
    }

}
