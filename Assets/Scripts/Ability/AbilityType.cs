using UnityEngine;
using System.Collections;

public class AbilityType
{
    protected Stype _abType;
    protected short _power;
    protected short _ttl; //How long the effect

    public enum Stype
    {
        None,
        Fire,
        Water,
        Rock,
        Wind
    }


    public AbilityType(Stype abType, short power, short ttl)
    {
        _abType = abType;
        _power = power;
        _ttl = ttl;
    }
    public virtual void RangedHit(GameObject target)
    {

    }
    public virtual void OnAreaHit(GameObject target)
    {

    }
    public virtual void MeleeHit(GameObject target)
    {

    }
}
