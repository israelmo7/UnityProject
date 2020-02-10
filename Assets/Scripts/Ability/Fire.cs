using UnityEngine;
using System.Collections;

public class Fire : AbilityType
{
    GameObject _FireEffect;
    public Fire(Stype abType, short power, short ttl) :
    base(abType, power, ttl)
    {
        _FireEffect = Resources.Load("VFX\\FireEffect") as GameObject;
        if(_FireEffect)
        {
            Debug.Log("YES");
        }
    }

    public override void RangedHit(GameObject target)
    {
        // Burn enemy for [ttl] sec a [power] damage
        
    }
    public override void OnAreaHit(GameObject target)
    {
        //Warm up Area
    }
    public override void MeleeHit(GameObject target)
    {
        //Infect enemeies with Burn [ttl] sec a [power]/5
    }
}
