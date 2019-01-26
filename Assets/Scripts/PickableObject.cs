using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Object
{
    [SerializeField]
    private Stat statToChange;

    public PickableObjectPool myPool;

    public enum Type
    {
        food, water, branch
    }
    public Type type;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            statToChange.currentValue++;
            myPool.AddToPool(this);

            //  GameManager.instance.PickupObject(type);
        }
    }

}
