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
        this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed.currentValue * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0)
        {
            player.setDirection(Creature.Direction.right);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            player.setDirection(Creature.Direction.left);
        }

        this.transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed.currentValue * Time.deltaTime);
    }
}
