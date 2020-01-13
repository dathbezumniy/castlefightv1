using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackCastleState : BaseState
{
    private float _attackReadyTimer;
    private FighterAI _fighter;

    public AttackCastleState(FighterAI fighter) : base(fighter.gameObject)
    {
        _fighter = fighter;
    }

    public override Type Tick()
    {
        var chaseTarget = CheckForAggro();
        if (chaseTarget != null)
        {
            _fighter.SetTarget(chaseTarget);
            return typeof(ChaseState);
        }

        _fighter.agent.isStopped = true;

        _attackReadyTimer -= Time.deltaTime;

        if (_attackReadyTimer <= 0f)
        {
            Debug.Log("Attack!");
            _fighter.Attack();
            _attackReadyTimer = 1.3f;
        }
        return null;
    }


    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    private Transform CheckForAggro()
    {
        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for (var i = 0; i < 72; i++)
        {
            if (Physics.Raycast(pos, direction, out hit, GameSettings.AggroRadius))
            {
                var unit = hit.collider.GetComponent<Unit>();
                if (unit != null && unit.team != gameObject.GetComponent<Unit>().team)
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return unit.transform;
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * GameSettings.AggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }
}
