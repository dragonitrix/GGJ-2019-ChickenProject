using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjectSpawner : MonoBehaviour
{
   [SerializeField]
   private PickableObject[] objectTypes;






    private void Awake()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {

    }
}
