using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatGrowth
{
    Low,
    Medium,
    High,
    Abnormal,
    LowtoHigh,
    HightoLow
}

[CreateAssetMenu(fileName = "New Character's Stats", menuName = "Character/CharacterStat")]
public class CharacterStatistics: ScriptableObject
{
    public string characterName;
    public int level;
    public int currentHP;
    public int maxHP;
    public int currentMP;
    public int maxMP;
    public int attack;
    public int defense;
    public int magic;
    public int resistance;
    public int efficiency;
    public int skill;
    public int speed;
    public string ability;
    [TextArea(15, 20)]
    public string abilityDescription;
    public Sprite image;
    public StatGrowth statGrowth;

    public List<MoveBaseClass> moveBaseClassList;
}
