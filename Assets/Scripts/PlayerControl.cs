using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Player player;
    private ChickenSpeed speed;


    void Start()
    {
        player = GetComponent<Player>();
        speed = GetComponent<ChickenSpeed>();
    }


    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.plane.GetComponent<Animator>().SetTrigger("squash_trigger");            
        }
    }



    void Move()
    {
        this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed.speed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed.speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0)
        {
            player.setDirection(Object.Direction.right);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            player.setDirection(Object.Direction.left);
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            player.plane.GetComponent<Animator>().SetBool("squash_bool", true);
        }
        else
        {
            player.plane.GetComponent<Animator>().SetBool("squash_bool", false);
        }

    }

}
