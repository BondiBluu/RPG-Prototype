using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boost
{
    None,
    ATTACK,
    DEFENSE,
    MAGIC,
    RES,
    EFF,
    SKILL,
    SPEED
}

public enum Status
{
    None,
    POISON,
    PARALYSIS,
    SLEEP,
    FREEZE,
    BURN,
    HEALBIND
}

public enum MoveType
{
    DAMAGING,
    SUPPLEMENTARY
}

public enum AttackType
{
    None,
    PHYSICAL,
    MAGICAL
}



[CreateAssetMenu(fileName = "New Move", menuName = "Move/NewMove")]
public class MoveBaseClass : ScriptableObject
{
    [SerializeField] string attackName;
    [TextArea]
    [SerializeField] string attackDesc;
    [SerializeField] int attackPower;
    [SerializeField] int mPConsumption;
    [SerializeField] int levelAqcuired;
    [SerializeField] int healAmount;
    [SerializeField] MoveType moveType;
    [SerializeField] AttackType attackType;
    [SerializeField] Boost[] buffTypes;
    [SerializeField] float buffAmount;
    [SerializeField] Boost[] debuffTypes;
    [SerializeField] float debuffAmount;

    //damage over time? Things like poison
    //number of attacks
    //number of people to attack
    //number of people to heal

    //we want NO ONE messing with these stats, that's why they're private. We need getters and setters
    public string AttackName
    {
        get { return attackName; }
        set { attackName = value; }
    }

    public string AttackDesc
    {
        get { return attackDesc; }
        set { attackDesc = value; }
    }

    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    public int MPConsumption
    {
        get { return mPConsumption; }
        set { mPConsumption = value; }
    }

    public Boost[] BuffTypes
    {
        get { return buffTypes; }
        set { buffTypes = value; }
    }
    public Boost[] DebuffTypes
    {
        get { return debuffTypes; }
        set { debuffTypes = value; }
    }

    public float BuffAmount
    {
        get { return buffAmount; }
        set { buffAmount = value; }
    }
     public float DebuffAmount
    {
        get { return debuffAmount; }
        set { debuffAmount = value; }
    }

    public int LevelAqcuired
    {
        get { return levelAqcuired; }
        set { levelAqcuired = value; }
    }

    public int HealAmount
    {
        get { return healAmount; }
        set { healAmount = value; }
    }

    public MoveType MoveType { 
        get { return moveType; }
        set {  moveType = value; } 
    }

    public AttackType AttackType
    {
        get { return attackType; }
        set { attackType = value; }
    }
}
