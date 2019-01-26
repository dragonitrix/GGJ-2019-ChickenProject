using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Object {
    public enum Type {
        item,
        trap
    }

    [SerializeField]
    private Stat statToChange;

    public Type type;
    public PickableObjectPool myPool;
    protected Action OnConsume = delegate { };

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.OnDayEnds += SelfDestruct;
    }


    protected void Start()
    {
        if (myPool == null)
            Debug.Log("I should be spawned through OjectPool!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (type) {
                case Type.item:
                    statToChange.currentValue++;
                    break;
                case Type.trap:
                    // implement here
                    break;
            }
            SelfDestruct();
        }
    }


    private void SelfDestruct()
    {
        myPool.AddToPool(this);
    }

}
