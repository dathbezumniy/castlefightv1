using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBuilding : Unit
{
    [SerializeField]
    protected float spawnCooldown;
    protected float timeToSpawn;

    [SerializeField]
    protected GameObject Unit;

    protected Grid grid;

    //abstract protected void SpawnUnit();
    ///abstract protected void AutoCast();
    //abstract protected void Sell();
    //abstract protected void Upgrade();
}



// Start is called before the first frame update
/*
private void Awake()
{
    eastTeamUnits = GameObject.Find("EastUnits").transform;
    westTeamUnits = GameObject.Find("WestUnits").transform;
}

// Update is called once per frame
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

}


private void SpawnUnit()
{
    currentSpawnUnit = Instantiate(spawnUnit, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f), Quaternion.identity);
    if (team)
    {
        currentSpawnUnit.transform.SetParent(westTeamUnits);
    }else
    {
        currentSpawnUnit.transform.SetParent(eastTeamUnits);
    }

    currentSpawnUnit = null;
}
*/
