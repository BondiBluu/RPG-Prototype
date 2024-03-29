using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatistics : ScriptableObject
{
    [SerializeField] string characterName;
    [SerializeField] int level;
    [SerializeField] int currentHP;
    [SerializeField] int maxHP;
    [SerializeField] int currentMP;
    [SerializeField] int maxMP;
    [SerializeField] int attackCurrent;
    [SerializeField] int attackBase;
    [SerializeField] int defenseCurrent;
    [SerializeField] int defenseBase;
    [SerializeField] int magicCurrent;
    [SerializeField] int magicBase;
    [SerializeField] int resistanceCurrent;
    [SerializeField] int resistanceBase;
    [SerializeField] int efficiencyCurrent;
    [SerializeField] int efficiencyBase;
    [SerializeField] int skillCurrent;
    [SerializeField] int skillBase;
    [SerializeField] int speedCurrent;
    [SerializeField] int speedBase;

    public virtual void Initialize()
    {
        // Common initialization logic for both characters and enemies
    }

    public string CharacterName
    {
        get { return characterName; }
        set { characterName = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int CurrentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }

    public int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }

    public int CurrentMP
    {
        get { return currentMP; }
        set { currentMP = value; }
    }

    public int MaxMP
    {
        get { return maxMP; }
        set { maxMP = value; }
    }

    public int BaseAttack
    {
        get { return attackBase; }
        set { attackBase = value; }
    }

    public int CurrentAttack
    {
        get { return attackCurrent; }
        set { attackCurrent = value; }
    }

    public int BaseDefense
    {
        get { return defenseBase; }
        set { defenseBase = value; }
    }
    public int CurrentDefense
    {
        get { return defenseCurrent; }
        set { defenseCurrent = value; }
    }

    public int BaseMagic
    {
        get { return magicBase; }
        set { magicBase = value; }
    }
    public int CurrentMagic
    {
        get { return magicCurrent; }
        set { magicCurrent = value; }
    }
    public int BaseResistance
    {
        get { return resistanceBase; }
        set { resistanceBase = value; }
    }

    public int CurrentResistance
    {
        get { return resistanceCurrent; }
        set { resistanceCurrent = value; }
    }
    public int BaseEfficiency
    {
        get { return efficiencyBase; }
        set { efficiencyBase = value; }
    }

    public int CurrentEfficiency
    {
        get { return efficiencyCurrent; }
        set { efficiencyCurrent = value; }
    }

    public int BaseSkill
    {
        get { return skillBase; }
        set { skillBase = value; }
    }

    public int CurrentSkill
    {
        get { return skillCurrent; }
        set { skillCurrent = value; }
    }

    public int BaseSpeed
    {
        get { return speedBase; }
        set { speedBase = value; }
    }

    public int CurrentSpeed
    {
        get { return speedCurrent; }
        set { speedCurrent = value; }
    }
}

public enum StatGrowths
{
    Low,
    Medium,
    High,
    Abnormal,
    LowtoHigh,
    HightoLow
}

public class PlayerStatistics : BaseStatistics
{
    [SerializeField] string ability;
    [TextArea(15, 20)]
    [SerializeField] string abilityDescription;
    [SerializeField] Sprite image;
    [SerializeField] StatGrowth statGrowth;

    public List<MoveBaseClass> moveBaseClassList;

    public override void Initialize()
    {
        // Additional initialization logic for characters
    }
    public string Ability
    {
        get { return ability; }
        set { ability = value; }
    }
    public string AbilityDesc
    {
        get { return abilityDescription; }
        set { abilityDescription = value; }
    }

    public StatGrowth StatGrowth
    {
        get { return statGrowth; }
        set { statGrowth = value; }
    }
}

public enum SpawnRates
{
    Low,
    High,
    Rare,
    NearImpossible
}

public class EnemyStatistic : BaseStatistics
{
    public SpawnRates spawnRates;

    public List<MoveBaseClass> moveBaseClassList;

    public override void Initialize()
    {
        // Additional initialization logic for enemies
    }

    public SpawnRates SpawnRate
    {
        get { return spawnRates; }
        set { spawnRates = value; }
    }
}


