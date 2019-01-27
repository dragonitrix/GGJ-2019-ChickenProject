using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Player player;
    private ChickenSpeed speed;

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
        this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed.speed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed.speed * Time.deltaTime);

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
