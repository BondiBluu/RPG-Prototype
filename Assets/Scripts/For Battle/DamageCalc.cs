using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour
{
    public int CalcDamage(Unit attacker, MoveBaseClass move, EnemyUnit theAttacked)
    {
        float damageOutput = (attacker.characterStats.attack * move.AttackPower) / (2 * theAttacked.enemyStats.defense);
        int finalResult = (int)Math.Ceiling(damageOutput);
        return finalResult;
    }
    public int EnemyCalc(EnemyUnit attacker, MoveBaseClass move, Unit theAttacked)
    {
        float damageOutput = (attacker.enemyStats.attack * move.AttackPower) / (2 * theAttacked.characterStats.defense);
        int finalResult = (int)Math.Ceiling(damageOutput);
        if(finalResult <= 0)
        {
            if(move.MoveType != MoveType.SUPPLEMENTARY)
            {
                finalResult = 1;
            }
        }
        return finalResult;
    }


}
