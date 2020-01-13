using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackType : MonoBehaviour
{
    protected string attackName;

    protected int dmgToHeavy;
    protected int dmgToUnarmored;
    protected int dmgToLight;
    protected int dmgToMedium;
    protected int dmgToFortified;
    protected int dmgToDivine;

    private void Awake()
    {
        Init();
    }

    abstract protected void Init();
}


class Normal : AttackType
{
    protected override void Init()
    {
        attackName = "Normal";
        dmgToMedium = 175;
        dmgToUnarmored = 105;
        dmgToHeavy = 100;
        dmgToLight = 70;
        dmgToFortified = 50;
        dmgToDivine = 25;
    }
}

class Chaos : AttackType
{
    protected override void Init()
    {
        attackName = "Chaos";
        dmgToMedium = 100;
        dmgToUnarmored = 100;
        dmgToHeavy = 100;
        dmgToLight = 100;
        dmgToFortified = 100;
        dmgToDivine = 100;
    }
}


class Magic : AttackType
{
    protected override void Init()
    {
        attackName = "Magic";
        dmgToMedium = 70;
        dmgToUnarmored = 105;
        dmgToHeavy = 175;
        dmgToLight = 100;
        dmgToFortified = 40;
        dmgToDivine = 25;
    }
}

class Pierce : AttackType
{
    protected override void Init()
    {
        attackName = "Pierce";
        dmgToMedium = 100;
        dmgToUnarmored = 105;
        dmgToHeavy = 70;
        dmgToLight = 175;
        dmgToFortified = 45;
        dmgToDivine = 25;
    }
}

class Siege : AttackType
{
    protected override void Init()
    {
        attackName = "Siege";
        dmgToMedium = 70;
        dmgToUnarmored = 100;
        dmgToHeavy = 70;
        dmgToLight = 70;
        dmgToFortified = 100;
        dmgToDivine = 20;
    }
}

class HeroAttack : AttackType
{
    protected override void Init()
    {
        attackName = "Hero";
        dmgToMedium = 110;
        dmgToUnarmored = 110;
        dmgToHeavy = 110;
        dmgToLight = 110;
        dmgToFortified = 60;
        dmgToDivine = 40;
    }
}

class None : AttackType
{
    protected override void Init()
    {
        attackName = "None";
    }
}
