using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour
{
    public int CalcDamage(Unit attacker, MoveBaseClass move, EnemyUnit theAttacked)
    {
        float damageOutput = 0f;
        int finalResult = 0;

        if (move.AttackType == AttackType.PHYSICAL)
        {
            damageOutput = (attacker.characterStats.attack * move.AttackPower) / (2 * theAttacked.enemyStats.defense);
            finalResult = (int)Math.Ceiling(damageOutput);
        }
        
        if (move.AttackType == AttackType.MAGICAL)
        {
            damageOutput = (attacker.characterStats.magic * move.AttackPower) / (2 * theAttacked.enemyStats.resistance);
            finalResult = (int)Math.Ceiling(damageOutput);
        }

        if(move.BoostAmount > 0)
        {
            //boost by that amount
            if(move.SupplementaryEffect == SupplementaryEffect.POSITIVE)
            {
                //boost
                //atk+(atk * .1(the boost amount))
                //target will be self
            }

            if (move.SupplementaryEffect == SupplementaryEffect.NEGATIVE)
            {
                //lower
            }
        }
        
        if (finalResult <= 0)
        {
            if (move.MoveType != MoveType.SUPPLEMENTARY)
            {
                finalResult += 1;
            }
        }
        return finalResult;

    }
    public int EnemyCalc(EnemyUnit attacker, MoveBaseClass move, Unit theAttacked)
    {
        float damageOutput = 0f;
        int finalResult = 0;

        if (move.AttackType == AttackType.PHYSICAL)
        {
            damageOutput = (attacker.enemyStats.attack * move.AttackPower) / (2 * theAttacked.characterStats.defense);
            finalResult = (int)Math.Ceiling(damageOutput);
        }

        if (move.AttackType == AttackType.PHYSICAL)
        {
            damageOutput = (attacker.enemyStats.magic * move.AttackPower) / (2 * theAttacked.characterStats.resistance);
            finalResult = (int)Math.Ceiling(damageOutput);
        }

        if (move.BoostAmount > 0)
        {
            //boost by that amount
            if (move.SupplementaryEffect == SupplementaryEffect.POSITIVE)
            {
                //boost
            }

            if (move.SupplementaryEffect == SupplementaryEffect.NEGATIVE)
            {
                //lower
            }
        }

        if (finalResult <= 0)
        {
            if(move.MoveType != MoveType.SUPPLEMENTARY)
            {
                finalResult += 1;
            }
        }
        return finalResult;
    }


}
