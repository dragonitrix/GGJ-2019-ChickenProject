using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Player player;
    private ChickenSpeed speed;
    private float boundary = 498;

    [SerializeField]
    private Stat foodStat, healthStat;


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
            // player.plane.GetComponent<Animator>().SetTrigger("squash_trigger");     
            if (foodStat.currentValue > 0 && healthStat.currentValue < healthStat.maxValue)
            {
                foodStat.currentValue--;
                healthStat.currentValue++;
            }
        }
    }



    void Move()
    {
        var h = Vector3.right * Input.GetAxis("Horizontal") * speed.speed * Time.deltaTime;
        var v = Vector3.forward * Input.GetAxis("Vertical") * speed.speed * Time.deltaTime;

        // limit horizonal movement
        if(this.transform.position.x >= boundary && h.x > 0) {
            h = Vector3.zero;
        } else if (this.transform.position.x <= -boundary && h.x < 0) {
            h = Vector3.zero;
        }

        // limit vertical movement
        if(this.transform.position.z >= boundary && v.z > 0) {
            v = Vector3.zero;
        } else if (this.transform.position.z <= -boundary && v.z < 0) {
            v = Vector3.zero;
        }

        this.transform.Translate(h);
        this.transform.Translate(v);

        if (Input.GetAxis("Horizontal") > 0)
        {
            player.setDirection(Object.Direction.left);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            player.setDirection(Object.Direction.right);
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
