using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object
{
    Light playerSpotlight;

    private void Start()
    {
        base.Start();
        playerSpotlight = transform.GetChild(1).gameObject.GetComponent<Light>();
    }

    private void Update()
    {
        playerSpotlight.intensity = (1 - GameManager.Instance.lightValue) * 10;
    }

}
