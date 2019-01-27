﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectPool : MonoBehaviour
{

    [SerializeField]
    private PickableObject[] objectTypes;

   private List<PickableObject> pool;

    private void Awake()
    {
        pool = new List<PickableObject>();
    }


    public PickableObject GetObject()
    {
        PickableObject newObject;

        if(pool.Count>0)
        {
            newObject = pool[0];
            pool.Remove(newObject);
           
        }
        else
        {
            newObject = Instantiate(objectTypes[Random.Range(0, objectTypes.Length)], Vector3.zero, Quaternion.identity);
            newObject.gameObject.transform.SetParent(this.transform);
           
        }        

        newObject.myPool = this;
        newObject.gameObject.SetActive(true);
        return newObject;
    }





    public void AddToPool(PickableObject addedObject)
    {
        pool.Add(addedObject);
        addedObject.gameObject.SetActive(false);
    }






}
