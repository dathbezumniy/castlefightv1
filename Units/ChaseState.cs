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
        var chaseTarget = _fighter.CheckForAggro();
        if (chaseTarget != null)
        {
            _fighter.SetTarget(chaseTarget);
            if (_fighter.reachedEndOfPath)
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
