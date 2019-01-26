using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Object
{
    [SerializeField]
    private Stat statToChange;

    public PickableObjectPool myPool;




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
            myPool.AddToPool(this);
        }
    }

}
