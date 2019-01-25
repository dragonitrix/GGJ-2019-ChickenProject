using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public Texture texture;
    GameObject plane;

    private void Start()
    {
        plane = transform.GetChild(0).gameObject;

        plane.GetComponent<Renderer>().material.SetTexture("_mainTex", texture);
    }

    public enum Direction
    {
        left,right
    }

    public Direction direction;

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


}
