using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public List<Texture> houseTextures;
    public Stat houseHealth;

   [SerializeField]
   private float timeUntilColliderWorks;

    [SerializeField]
    private GlobalLightController lightController;

    private float counter;

    private BoxCollider MyCollider;




    private void Awake()
    {
       GameManager.Instance.OnDayStarts += NewDay;
        MyCollider = GetComponent<BoxCollider>();
        MyCollider.enabled = false;

    }


    public void NewDay()
    {
        counter = timeUntilColliderWorks;
        MyCollider.enabled = false;
    }

    private void Update()
    {
        if (houseHealth.currentValue > houseHealth.maxValue / 2f) {
            GetComponent<Object>().SetTexture(houseTextures[0]);
        } else if (houseHealth.currentValue > houseHealth.maxValue / 4f) {
            GetComponent<Object>().SetTexture(houseTextures[1]);
        } else {
            GetComponent<Object>().SetTexture(houseTextures[2]);
        }

        if (counter < 0) return;

        counter -= Time.deltaTime;
        if(counter < 0)
            MyCollider.enabled = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChickenReturnsHome();
        }
    }

    private void ChickenReturnsHome()
    {
        GameManager.Instance.ChickenReturnsHome();
    }
}
