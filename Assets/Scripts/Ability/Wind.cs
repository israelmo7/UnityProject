using UnityEngine;
using System.Collections;

public class Wind : AbilityType
{
    GameObject _arrowSource;
    public Wind(Stype abType, short power, short ttl) :
    base(abType, power, ttl)
    {
        _arrowSource = Resources.Load("arrow.prefab") as GameObject;
    }

    public override void RangedHit(GameObject target)
    {
        //Force target to some side
    }
    public override void OnAreaHit(GameObject target)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x += 3;
        GameObject obj = GameObject.Instantiate(_arrowSource, mousePos, Quaternion.identity);
    }
    public override void MeleeHit(GameObject target)
    {
        //Force Enemy to some side
    }
    private void DrawArrow()
    {

    }
}
