using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnRate
{
    Low,
    High,
    Rare,
    NearImpossible
}

[CreateAssetMenu(fileName = "New Enemy's Stats", menuName = "Character/EnemyStat")]
public class EnemyStatistics : ScriptableObject
{
    public string enemyName;
    public int level;
    public int currentHP;
    public int maxHP;
    public int attack;
    public int defense;
    public int magic;
    public int resistance;
    public int efficiency;
    public int skill;
    public int speed;
    public string ability;
    //itemObject?
    SpawnRate spawnRate;

    public List<MoveBaseClass> moveBaseClassList;

}
