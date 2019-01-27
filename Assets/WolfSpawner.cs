using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius, distanceBetweenPoints, offset;

    [SerializeField]
    private WolfPool pool;

    [SerializeField]
    private Stat dayLight;
         

    float timeCounter = 0;
    float waveDuration = 3;

    void Update()
    {
        if (GameManager.Instance.dayState == GameManager.DayState.night)
        {
            if (timeCounter < waveDuration)
            {
                timeCounter += Time.deltaTime;
            }
            else
            {
                if(Random.Range(0f, 1f) > dayLight.currentValue) 
                SpawnWolf();

                timeCounter = 0;
            }
        }
    }


    public void SpawnWolf()
    {
        var rot = Random.Range(0f, Mathf.PI) + Mathf.PI / 2;
        var lDirection = new Vector3(Mathf.Sin(rot), 0, Mathf.Cos(rot));

        if (Random.Range(0f, 1f) >= 0.5f)
        {
            var targetVector = transform.position + (lDirection * spawnRadius);
            var wolf = GetWolf(new Vector3(targetVector.x, transform.position.y, targetVector.z));

            wolf.attackTarget = Wolf.AttackTarget.home;
        }
        else
        {
            var targetVector = GameManager.Instance.playerTransform.position + (lDirection * spawnRadius);
            var wolf = GetWolf(new Vector3(targetVector.x, transform.position.y, targetVector.z));

            wolf.attackTarget = Wolf.AttackTarget.player;
        }
    }
       


    private Wolf GetWolf(Vector3 spawnPosition)
    {        
        Wolf newObject = pool.GetObject();
        newObject.transform.position = spawnPosition;

        return newObject;
    }

}
