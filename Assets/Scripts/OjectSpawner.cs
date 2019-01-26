//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjectSpawner : MonoBehaviour
{
    [SerializeField]
    private PickableObject[] objectTypes;

    [SerializeField]
    private float spawnRadius, distanceBetweenPoints, offset;

    [SerializeField]
    private PickableObjectPool pool;

    private void Awake()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        var spawnXpos = transform.position.x - spawnRadius;
        var spawnZpos = transform.position.z - spawnRadius;

        while (spawnXpos < transform.position.x + spawnRadius)
        {
            spawnZpos = transform.position.z - spawnRadius;

            while (spawnZpos < transform.position.z + spawnRadius)
            {

                spawnZpos += distanceBetweenPoints;

                CheckToSpawnHere();
            }
            spawnXpos += distanceBetweenPoints;

        }


        void CheckToSpawnHere()
        {
            var offsetX = Random.Range(-offset, offset);
            var offsetZ = Random.Range(-offset, offset);
            var spawnPosition = new Vector3(spawnXpos+ offsetX, transform.position.y, spawnZpos + offsetZ);

            PickableObject newObject = pool.GetObject();

            newObject.transform.position = spawnPosition;
        }

    }


}
