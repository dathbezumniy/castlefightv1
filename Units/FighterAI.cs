using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;


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
    public Health Health => GetComponent<Health>();

    private Seeker Seeker => GetComponent<Seeker>();
    private CharacterController CharController => GetComponent<CharacterController>();
    public Path path;
    public float nextWaypointDistance = 1;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;


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
        Seeker.StartPath(transform.position, Target.position, OnPathComplete);
    }

    public void SetCastleTarget()
    {
        Target = enemyCastle;
        Seeker.StartPath(transform.position, Target.position, OnPathComplete);
    }


    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        if (!p.error)
        {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }

    public void Update() {

        if (Health.currentHealth <= 0)
        {
            Die();
        }

        if (Target != null)
        {
            if (path == null)
            {
                // We have no path to follow yet, so don't do anything
                return;
            }

            // Check in a loop if we are close enough to the current waypoint to switch to the next one.
            // We do this in a loop because many waypoints might be close to each other and we may reach
            // several of them in the same frame.
            reachedEndOfPath = false;
            // The distance to the next waypoint in the path
            float distanceToWaypoint;
            while (true)
            {
                // If you want maximum performance you can check the squared distance instead to get rid of a
                // square root calculation. But that is outside the scope of this tutorial.
                //Vector3 offset = transform.position - path.vectorPath[currentWaypoint];
                distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
                if (distanceToWaypoint < nextWaypointDistance)
                {
                    // Check if there is another waypoint or if we have reached the end of the path
                    if (currentWaypoint + 1 < path.vectorPath.Count)
                    {
                        currentWaypoint++;
                    }
                    else
                    {
                        // Set a status variable to indicate that the agent has reached the end of the path.
                        // You can use this to trigger some special code if your game requires that.
                        reachedEndOfPath = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;
            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            Vector3 velocity = dir * speed * speedFactor;
            CharController.SimpleMove(velocity);
        }
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
