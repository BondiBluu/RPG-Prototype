using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageCalc : MonoBehaviour
{
    public string message = "";
    public int CalcDamage(Unit attacker, MoveBaseClass move, Unit theTarget)
    {
        float damageOutput = 0f;
        int finalResult = 0;

        switch (move.AttackType)
        {
            case AttackType.PHYSICAL:
                {
                    //so there's no divide by 0 error, the divisor, if not anything higher than 0, will be 1.
                    damageOutput = (attacker.characterStats.CurrentAttack * move.AttackPower) / (2 * Math.Max(1, theTarget.characterStats.CurrentDefense));
                    finalResult = (int)Math.Ceiling(damageOutput);
                    message += $"{attacker.characterStats.CharacterName} used {move.AttackName} on {theTarget.characterStats.CharacterName}! Did {finalResult} damage!";
                    break;
                }
            case AttackType.MAGICAL:
                {
                    damageOutput = (attacker.characterStats.CurrentMagic * move.AttackPower) / (2 * Math.Max(1, theTarget.characterStats.CurrentResistance));
                    finalResult = (int)Math.Ceiling(damageOutput);
                    message += $"{attacker.characterStats.CharacterName} used {move.AttackName} on {theTarget.characterStats.CharacterName}! Did {finalResult} damage!";
                    break;
                }
        }

        if(move.BuffTypes.Length > 0)
        {
            //the attacker applies the buff on whatever ally- be it themselves or someone else
            theTarget.ApplyBuff(move.BuffTypes, move.BuffAmount);

            //adding the buffs to the message
            message += $"{attacker.characterStats.CharacterName} uses {move.AttackName} on {theTarget.characterStats.CharacterName}! {theTarget.characterStats.CharacterName}'s";
            //naming all the buffs that were in that attack
            for (int i = 0; i < move.BuffTypes.Length; i++)
            {
                message += $" {move.BuffTypes[i]}";
                if(i < move.BuffTypes.Length - 1)
                {
                    message += ",";
                }
            }
            message += $" raised!";
        }

        if(move.DebuffTypes.Length > 0)
        {
            //applying any debuff on the target
            theTarget.ApplyBuff(move.DebuffTypes, move.DebuffAmount);

            message += $"{attacker.characterStats.CharacterName} uses {move.AttackName} on {theTarget.characterStats.CharacterName}! {theTarget.characterStats.CharacterName}'s";

            for (int i = 0; i < move.DebuffTypes.Length; i++)
            {
                message += $" {move.DebuffTypes[i]}";
                if (i < move.DebuffTypes.Length - 1)
                {
                    message += ",";
                }
            }
            message += $" lowered!";
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

    void CalcHeal() { }
}

