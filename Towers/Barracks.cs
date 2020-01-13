using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Building
{
    private Transform westTeamUnits;

    public override void Init()
    {
        firstName = "Barracks";
        team = true;
        cost = 100;
        health.maxHealth = 1200;
        health.healthRegeneration = 0f;
        armorType = new Fortified();
        armor = 5;
        physicalResistance = 0.22f;
        spawnCooldown = 20f;
    }

    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
        Init();
        health.currentHealth = health.maxHealth;
        westTeamUnits = GameObject.Find("WestUnits").transform;
    }

    void Update()
    {
        if (Mathf.RoundToInt(timeToSpawn) == 0)
        {
            SpawnUnit();
            timeToSpawn = spawnCooldown;
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }

        if (health.currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    public override void SpawnUnit()
    {
        currentSpawnUnit = Instantiate(SpawnUnitPrefab, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f), Quaternion.identity);
        currentSpawnUnit.transform.SetParent(westTeamUnits);
        currentSpawnUnit = null;
    }

    public override void DestroyBuilding()
    {
        Destroy(gameObject);
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
