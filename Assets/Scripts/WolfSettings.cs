using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WolfSettings : ScriptableObject
{
    public float chaseRadius;
    public float chaseSpeed;

    public float fleeRadius;
    public float fleeSpeed;

    public float attackdelay;
    public int attackDamage;

}
