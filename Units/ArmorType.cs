using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmorType : MonoBehaviour
{
    public string armorName;
    public float dmgFromHero;
    public float dmgFromNormal;
    public float dmgFromPierce;
    public float dmgFromMagic;
    public float dmgFromChaos;
    public float dmgFromSiege;

    private void Awake()
    {
        Init();
    }

    abstract protected void Init();
}

class Unarmored : ArmorType
{
    protected override void Init()
    {
        armorName = "Unarmored";
        dmgFromHero = 1.1f;
        dmgFromNormal = 1.05f;
        dmgFromPierce = 1.05f;
        dmgFromMagic = 1.05f;
        dmgFromChaos = 1f;
        dmgFromSiege = 1f;
    }
}


class Heavy : ArmorType
{
    protected override void Init()
    {
        armorName = "Heavy";
        dmgFromHero = 1.1f;
        dmgFromNormal = 1f;
        dmgFromPierce = 0.7f;
        dmgFromMagic = 1.75f;
        dmgFromChaos = 1f;
        dmgFromSiege = 0.7f;
    }
}


class Medium : ArmorType
{
    protected override void Init()
    {
        armorName = "Medium";
        dmgFromHero = 1.1f;
        dmgFromNormal = 1.75f;
        dmgFromPierce = 1f;
        dmgFromMagic = 0.7f;
        dmgFromChaos = 1f;
        dmgFromSiege = 0.7f;
    }
}

class Light : ArmorType
{
    protected override void Init()
    {
        armorName = "Light";
        dmgFromHero = 1.1f;
        dmgFromNormal = 0.7f;
        dmgFromPierce = 1.75f;
        dmgFromMagic = 1f;
        dmgFromChaos = 1f;
        dmgFromSiege = 0.7f;
    }
}


class Divine : ArmorType
{
    protected override void Init()
    {
        armorName = "Divine";
        dmgFromHero = 0.4f;
        dmgFromNormal = 0.25f;
        dmgFromPierce = 0.25f;
        dmgFromMagic = 0.25f;
        dmgFromChaos = 1f;
        dmgFromSiege = 0.2f;
    }
}


class HeroArmor : ArmorType
{
    protected override void Init()
    {
        armorName = "Hero";
        dmgFromHero = 0.6f;
        dmgFromNormal = 0.6f;
        dmgFromPierce = 0.6f;
        dmgFromMagic = 0.6f;
        dmgFromChaos = 1f;
        dmgFromSiege = 0.4f;
    }
}



class Fortified : ArmorType
{
    protected override void Init()
    {
        armorName = "Fortified";
        dmgFromHero = 0.6f;
        dmgFromNormal = 0.5f;
        dmgFromPierce = 0.45f;
        dmgFromMagic = 0.4f;
        dmgFromChaos = 1f;
        dmgFromSiege = 1f;
    }
}



