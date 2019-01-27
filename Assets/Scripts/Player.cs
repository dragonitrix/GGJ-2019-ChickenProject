using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object
{
    Light playerSpotlight;

    private Vector3 startPosition;


    private void OnEnable()
    {
        GameManager.Instance.OnDayStarts += ResetPosition;
        
    }
    private void OnDisable()
    {
        GameManager.Instance.OnDayStarts -= ResetPosition;
    }

    protected override void Awake()
    {
        base.Awake();
        playerSpotlight = transform.GetChild(1).gameObject.GetComponent<Light>();
        startPosition = transform.position;
    }

    private void Update()
    {
        playerSpotlight.intensity = (1 - GameManager.Instance.lightValue) * 10;
    }

    private void ResetPosition()
    {
        if (startPosition != null)
            transform.position = startPosition;

    }

}
