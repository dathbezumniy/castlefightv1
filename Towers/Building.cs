using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Unit
{
    protected int cost;

    protected float startingHealth;

    [SerializeField]
    protected GameObject SpawnUnitPrefab;
    protected GameObject currentSpawnUnit;
    protected float spawnCooldown;
    protected float timeToSpawn;


    private void Awake()
    {
        Init();
    }

    abstract public void Init();
    abstract public void SpawnUnit();
    abstract public void DestroyBuilding();
    abstract public void Upgrade();
}
