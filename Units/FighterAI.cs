using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public enum FighterState
{
    TargetCastle,
    Chase,
    Attack
}

public class FighterAI : Unit
{
    public Transform enemyCastle;
    public Transform Target { get; private set; }
    public StateMachine StateMachine => GetComponent<StateMachine>();

    protected void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(TargetCastleState), new TargetCastleState(this) },
            {typeof(ChaseState), new ChaseState(this) },
            {typeof(AttackState), new AttackState(this) }
        };

        GetComponent<StateMachine>().SetStates(states);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void SetCastleTarget()
    {
        Target = enemyCastle;
    }

    public void Attack()
    {
        Target.gameObject.GetComponent<Health>().ModifyHealth(-attackDamage);
    }


    public void Die()
    {
        Destroy(gameObject);
    }


    public List<Unit> GetNearbyEnemyFighters(Vector3 origin, float radius)
    {
        Collider[] cols = Physics.OverlapSphere(origin, radius);
        if (cols.Length > 0)
        {
            List<Unit> nearbyEnemyFighters = new List<Unit>();
            for (var i = 0; i < cols.Length; i++)
            {
                Type counterType = cols[i].GetType();
                if (counterType == typeof(CapsuleCollider))
                {
                    if (cols[i].GetComponent<Unit>() != null && cols[i].GetComponent<Unit>().team != team)
                    {
                        nearbyEnemyFighters.Add(cols[i].GetComponent<Unit>());
                    }
                }
            }
            return nearbyEnemyFighters;
        }
        return null;
    }



    public List<Building> GetNearbyEnemyBuildings(Vector3 origin, float radius)
    {
        Collider[] cols = Physics.OverlapSphere(origin, radius);
        if (cols.Length > 0)
        {
            List<Building> nearbyEnemyBuildings = new List<Building>();
            for (var i = 0; i < cols.Length; i++)
            {
                Type counterType = cols[i].GetType();
                if (counterType == typeof(BoxCollider))
                {
                    if (cols[i].GetComponent<Building>() != null && cols[i].GetComponent<Building>().team != team)
                    {
                        nearbyEnemyBuildings.Add(cols[i].GetComponent<Building>());
                    }
                }
            }
            return nearbyEnemyBuildings;
        }
        return null;
    }


    public Transform CheckForAggro()
    {

        List<Unit> nearbyUnits = this.GetNearbyEnemyFighters(this.transform.position, GameSettings.AggroRadius);
        List<Building> nearbyBuildings = this.GetNearbyEnemyBuildings(this.transform.position, GameSettings.AggroRadius);

        if (nearbyUnits.Count > 0)
        {
            Unit closest = nearbyUnits[0];
            for (int i = 0; i < nearbyUnits.Count; i++)
            {
                Vector3 closestOffset = closest.transform.position - transform.position;
                Vector3 offset = nearbyUnits[i].transform.position - transform.position;
                float closestSqrLen = closestOffset.sqrMagnitude;
                float sqrLen = offset.sqrMagnitude;
                if (sqrLen < closestSqrLen)
                {
                    closest = nearbyUnits[i];
                }
            }
            return closest.transform;
        }
        else if (nearbyUnits.Count <= 0 && nearbyBuildings.Count > 0)
        {
            Unit closest = nearbyBuildings[0];
            for (int i = 0; i < nearbyBuildings.Count; i++)
            {
                Vector3 closestOffset = closest.transform.position - transform.position;
                Vector3 offset = nearbyBuildings[i].transform.position - transform.position;
                float closestSqrLen = closestOffset.sqrMagnitude;
                float sqrLen = offset.sqrMagnitude;
                if (sqrLen < closestSqrLen)
                {
                    closest = nearbyBuildings[i];
                }
            }
            return closest.transform;
        }
        return null;
    }
}
