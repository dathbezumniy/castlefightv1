using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Unit
{
    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
        Init();
        health.currentHealth = health.maxHealth;
    }

    public void Init()
    {
        team = true;
        armorType = new Fortified();
        armor = 10;
        physicalResistance = 0.37f;
        health.maxHealth = 5000;
        health.healthRegeneration = 3f;
    }
}
