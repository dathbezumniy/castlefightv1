using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Footman : FighterAI
{
    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        Init();
        health.currentHealth = health.maxHealth;
        InitializeStateMachine();
        enemyCastle = GameObject.Find("EastCastle").transform;
    }

    public void Init()
    {
        team = true;
        firstName = "Footman";
        speed = 5;
        armor = 4;
        attackDamage = 25;
        physicalResistance = 0.19f;
        health.maxHealth = 200;
        health.healthRegeneration = 0.5f;
        attackRange = 128;
        attackSpeed = 121;
        moveSpeed = 270;
        attackType = new Normal();
        armorType = new Heavy();
        bounty = 2;
    }


    void Update()
    {
        if (health.currentHealth <= 0)
        {
            Die();
        }
    }
}
