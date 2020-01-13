using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected string firstName;

    [SerializeField]
    public bool team;

    protected int armor;
    public int attackRange;
    protected int attackSpeed;
    protected int moveSpeed;
    protected int attackDamage;
    protected int bounty;
    protected int speed;

    protected Health health;
    protected float healthRegeneration;
    protected float physicalResistance;

    protected ArmorType armorType;
    protected AttackType attackType;
    protected List<Ability> abilities;
}