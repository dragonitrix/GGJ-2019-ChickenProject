using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
   [SerializeField]
   private float timeUntilColliderWorks;

    private float counter;

    private BoxCollider MyCollider;

    private void Awake()
    {
       GameManager.Instance.OnNewDayStarts += NewDay;
        MyCollider = GetComponent<BoxCollider>();
    }


    public void NewDay()
    {
        counter = timeUntilColliderWorks;
        MyCollider.enabled = false;
    }

    private void Update()
    {
        if(counter < 0) return;

        counter -= Time.deltaTime;
        if(counter < 0)
            MyCollider.enabled = true;
    }




}
