using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{
    public GlobalScriptTeam _gs;
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    private float MAX_TIME = 0.5f;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    
    public static Dictionary<string, GameObject> visibleTargets = new Dictionary<string,GameObject>();

    private void Start()
    {
        _gs = GameObject.FindGameObjectWithTag("Manager").GetComponent<GlobalScriptTeam>();
    }

    private void Update()
    {
        FindVisibleTargets();
    }
    void FindVisibleTargets()
    {
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                if (target.tag == "Enemy" && !Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    _gs.AddObject(target.gameObject,MAX_TIME);
                }
            }
        }
    }




}

