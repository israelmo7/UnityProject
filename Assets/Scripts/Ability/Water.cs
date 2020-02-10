using UnityEngine;
using System.Collections;

public class Water : AbilityType
{
    public Water(Stype abType, short power, short ttl):
        base(abType,power,ttl)
    {

    }

    public override void RangedHit(GameObject target)
    {
       //
       //
    }
    public override void OnAreaHit(GameObject target)
    {

    }
    public override void MeleeHit(GameObject target)
    {

    }
}
