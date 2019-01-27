using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Wolf : Object
{

    public WolfPool myPool;

     public WolfSettings settings;

    public enum WolfState
    {
        chasing,fleeing,idle
    }



    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.OnDayEnds += Endday;
    }
    



    public WolfState wolfState;



    public void setState(WolfState targetState)
    {
        wolfState = targetState;
        switch (wolfState)
        {
            case WolfState.chasing:
                plane.GetComponent<Animator>().SetBool("squash_bool", true);
                break;
            case WolfState.fleeing:
                plane.GetComponent<Animator>().SetBool("squash_bool", true);
                break;
            case WolfState.idle:
                plane.GetComponent<Animator>().SetBool("squash_bool", false);
                break;
            default:
                break;
        }
    }




    public Stat playerHealth;
    public Stat homeHealth;
    float attackTimer = 0;

    public Transform target;

    public enum AttackTarget
    {
        player,home
    }
    public AttackTarget attackTarget;

    public void fleeFrom(Transform target)
    {
        this.target = target;
        setState(WolfState.fleeing);
    }

    public void ChaseTo(Transform target)
    {
        this.target = target;
        setState(WolfState.chasing);
    }


    private void Start()
    {
        switch (attackTarget)
        {
            case AttackTarget.player:
                ChaseTo(GameManager.Instance.playerTransform);
                break;
            case AttackTarget.home:
                ChaseTo(GameManager.Instance.houseTransform);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (wolfState)
        {
            case WolfState.chasing:

                var chaseVector = target.position - transform.position;
                var chasedistance = chaseVector.magnitude;

                if (chasedistance > settings.chaseRadius)
                {
                    var deltaVector = chaseVector.normalized * settings.chaseSpeed * Time.deltaTime;
                    deltaVector.y = 0;
                    transform.Translate(deltaVector);
                }
                else
                {
                    setState(WolfState.idle);
                }

                break;
            case WolfState.fleeing:
                
                var fleeVector = transform.position - target.position;
                var fleedistance = fleeVector.magnitude;

                if (fleedistance < settings.fleeRadius)
                {
                    var deltaVector = fleeVector.normalized * settings.chaseSpeed * Time.deltaTime;
                    deltaVector.y = 0;
                    transform.Translate(deltaVector);
                }
                else
                {
                    setState(WolfState.idle);
                }

                break;
            case WolfState.idle:

                var idleVector = target.position - transform.position;
                var idledistance = idleVector.magnitude;

                if (idledistance <= settings.chaseRadius)
                {
                    if (attackTimer < settings.attackdelay)
                    {
                        attackTimer += Time.deltaTime;
                    }
                    else
                    {
                        attackTimer = 0;
                        Attack();
                    }
                }
                else
                {
                    setState(WolfState.chasing);
                }
                
                break;
            default:
                break;
        }
    }

    void Attack()
    {
        plane.GetComponent<Animator>().SetTrigger("squash_trigger");

        switch (attackTarget)
        {
            case AttackTarget.player:
                playerHealth.currentValue -= settings.attackDamage;
                break;
            case AttackTarget.home:
                homeHealth.currentValue -= settings.attackDamage;
                break;
            default:
                break;
        }

    }

    void Endday()
    {
        fleeFrom(GameManager.Instance.houseTransform);

        Invoke("SelfDestruct", 2);
    }

    private void SelfDestruct()
    {        
        myPool.AddToPool(this);
    }

}
