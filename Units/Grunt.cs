using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Grunt : FighterAI
{
    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
        Init();
        health.currentHealth = health.maxHealth;
        InitializeStateMachine();
        enemyCastle = GameObject.Find("WestCastle").transform;
    }

    public void Init()
    {
        team = false;
        firstName = "Grunt";
        speed = 5;
        armor = 4;
        attackDamage = 27;
        physicalResistance = 0.19f;
        health.maxHealth = 325;
        health.healthRegeneration = 0.5f;
        attackRange = 128;
        attackSpeed = 113;
        moveSpeed = 270;
        attackType = new Normal();
        armorType = new Heavy();
        bounty = 2;
    }
}






