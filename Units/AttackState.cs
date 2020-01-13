using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float _attackReadyTimer;
    private FighterAI _fighter;

    public AttackState(FighterAI fighter) : base(fighter.gameObject)
    {
        _fighter = fighter;
    }

    public override Type Tick()
    {
        var chaseTarget = _fighter.CheckForAggro();
        if (chaseTarget != _fighter.Target)
        {
            _fighter.SetTarget(chaseTarget);
            _fighter.agent.SetDestination(chaseTarget.transform.position);
            return typeof(ChaseState);
        }

        if (!_fighter.agent.hasPath || _fighter.Target == null)
        {
            return typeof(TargetCastleState);
        }

        _fighter.agent.isStopped = true;
        _attackReadyTimer -= Time.deltaTime;

        if(_attackReadyTimer <= 0f)
        {
            Debug.Log("Attack!");
            _fighter.Attack();
            _attackReadyTimer = 1.3f;
        }
        return null;
    }
}
