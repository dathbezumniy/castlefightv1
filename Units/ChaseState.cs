using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private FighterAI _fighter;

    public ChaseState(FighterAI fighter): base(fighter.gameObject)
    {
        _fighter = fighter;
    }

    public override Type Tick()
    {
        _fighter.agent.isStopped = false;
        var chaseTarget = _fighter.CheckForAggro();
        if (chaseTarget != null)
        {
            _fighter.SetTarget(chaseTarget);
            _fighter.agent.SetDestination(chaseTarget.transform.position);
            if (_fighter.agent.remainingDistance <= _fighter.agent.stoppingDistance * _fighter.attackRange * 0.02f)
            {
                return typeof(AttackState);
            }
        }

        if(_fighter.Target == null)
        {
            return typeof(TargetCastleState);
        }
        return null;
    }
}
