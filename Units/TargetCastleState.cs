using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetCastleState : BaseState
{
    private FighterAI _fighter;
    private float _attackReadyTimer;

    public TargetCastleState(FighterAI fighter) : base(fighter.gameObject)
    {
        _fighter = fighter;
    }

    public override Type Tick()
    {
        var chaseTarget = _fighter.CheckForAggro();
        if (chaseTarget != null)
        {
            _fighter.SetTarget(chaseTarget);
            return typeof(ChaseState);
        }

        if (_fighter.Target == null)
        {
            _fighter.SetCastleTarget();
        }


        // this should probably be a new state something like "AttackCastleState"
        //or "AttackBuildingState" since all fighters share similar building aggro mechanics
        if (!_fighter.agent.pathPending)
        {
            if (_fighter.agent.remainingDistance <= _fighter.agent.stoppingDistance * _fighter.attackRange * 0.02f)
            {
                _attackReadyTimer -= Time.deltaTime;
                if (_attackReadyTimer <= 0f)
                {
                    Debug.Log("Attack!");
                    _fighter.Attack();
                    _attackReadyTimer = 1.3f;
                }
            }
        }
            
        return null;
    }
}

