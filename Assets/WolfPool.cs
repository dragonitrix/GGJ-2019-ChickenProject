using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPool : MonoBehaviour
{
    private List<Wolf> pool;

    [SerializeField]
    private Wolf[] objectTypes;

    private void Awake()
    {
        pool = new List<Wolf>();
    }


    public Wolf GetObject()
    {
        Wolf newObject;

        if (pool.Count > 0)
        {
            newObject = pool[0];

        }
        else
        {
            newObject = Instantiate(objectTypes[Random.Range(0, objectTypes.Length)], Vector3.zero, Quaternion.identity);
            newObject.gameObject.transform.SetParent(this.transform);
        }

        newObject.myPool = this;
        return newObject;
    }


    public void AddToPool(Wolf addedObject)
    {
        pool.Add(addedObject);
        addedObject.gameObject.SetActive(false);
    }




}
