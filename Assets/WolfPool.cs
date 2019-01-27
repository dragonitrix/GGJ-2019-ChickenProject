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
        Wolf newWolf;

        if (pool.Count > 0)
        {
            newWolf = pool[0];
            pool.Remove(newWolf);

        }
        else
        {
            newWolf = Instantiate(objectTypes[Random.Range(0, objectTypes.Length)], Vector3.zero, Quaternion.identity);
            newWolf.gameObject.transform.SetParent(this.transform);
        }

        newWolf.myPool = this;
        newWolf.gameObject.SetActive(true);
        return newWolf;
    }


    public void AddToPool(Wolf addedObject)
    {
        pool.Add(addedObject);
        addedObject.gameObject.SetActive(false);
    }




}
