using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Stat speed;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        speed.currentValue = speed.initValue;
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.plane.GetComponent<Animator>().SetTrigger("squash_trigger");
            
        }

    }

    void move()
    {
        this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed.currentValue * Time.deltaTime);
        this.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed.currentValue * Time.deltaTime);

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
