using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius, distanceBetweenPoints, offset;

    [SerializeField]
    private WolfPool pool;

    private void Awake()
    {
        GameManager.Instance.OnDayEnds += ClearObjects;
    }
    
    
    private void ClearObjects()
    {


    }

    float timeCounter = 0;
    float waveDuration = 3;

    // Update is called once per frame
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
                Debug.Log("wolfspawn");
                timeCounter = 0;
                
                var rot = Random.Range(0f, Mathf.PI) + Mathf.PI/2;

                var lDirection = new Vector3(Mathf.Sin(rot), 0 ,Mathf.Cos(rot));

                if (Random.Range(0f,1f) >= 0.5f)
                {
                    var targetVector = transform.position + (lDirection * spawnRadius);
                    var wolf = Spawn(new Vector3(targetVector.x, transform.position.y, targetVector.z));

                    wolf.attackTarget = Wolf.AttackTarget.home;

                    //wolf.ChaseTo(GameManager.Instance.houseTransform);
                }
                else
                {
                    var targetVector = GameManager.Instance.playerTransform.position + (lDirection * spawnRadius);
                    var wolf = Spawn(new Vector3(targetVector.x, transform.position.y, targetVector.z));

                    wolf.attackTarget = Wolf.AttackTarget.player;

                    //wolf.ChaseTo(GameManager.Instance.playerTransform);
                }

            }
        }   
    }

    Wolf Spawn(Vector3 spawnPosition)
    {
        Wolf newObject = pool.GetObject();
        newObject.transform.position = spawnPosition;

        return newObject;
    }

}
