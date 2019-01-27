﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public Texture texture;
    [HideInInspector]
    public GameObject plane;
    [HideInInspector]
    public Direction direction;

    protected virtual void Awake()
    {
        plane = transform.GetChild(0).gameObject;
        SetTexture(texture);
    }

    public enum Direction
    {
        left,right
    }


    public void setDirection(Direction direction)
    {

        var dir = 1;

        switch (direction)
        {
            case Direction.left:
                dir = -1;
                break;
            case Direction.right:
                dir = 1;
                break;
            default:
                break;
        }

        plane.GetComponent<Renderer>().material.mainTextureScale = new Vector2(dir, 1);

    }

    // can globally set texture
    public void SetTexture(Texture tx) {
        plane.GetComponent<Renderer>().material.SetTexture("_MainTex", tx);
    }
}
