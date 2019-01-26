using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Object
{
    [SerializeField]
    private Stat statToChange;

    public enum Type
    {
        food,water,branch
    }
    public Type type;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.dayState == GameManager.DayState.day)
        {

            statToChange.currentValue ++;           
              //  GameManager.instance.PickupObject(type);
                Destroy(gameObject);
            
        }
    }

}
