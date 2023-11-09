using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageCalc : MonoBehaviour
{
    public string message = "";
    public string damageResult = "";
    public int finalResult = 0;
    
    public void CalcDamage(Unit attacker, MoveBaseClass move, Unit theTarget)
    {
        float damageOutput = 0f;

        message += $"{attacker.characterStats.CharacterName} used {move.AttackName} on {theTarget.characterStats.CharacterName}!";
        StartCoroutine(attacker.TakeMP(move.MPConsumption));

        switch (move.AttackType)
        {
            case AttackType.PHYSICAL:
                {
                    //so there's no divide by 0 error, the divisor, if not anything higher than 0, will be 1.
                    damageOutput = (attacker.characterStats.CurrentAttack * move.AttackPower) / (2 * Math.Max(1, theTarget.characterStats.CurrentDefense));
                    finalResult = (int)Math.Ceiling(damageOutput);

                    if (finalResult <= 0)
                    {
                        if (move.MoveType != MoveType.SUPPLEMENTARY)
                        {
                            finalResult += 1;
                        }
                    }
                    //theTarget.TakeDamage(finalResult);
                    StartCoroutine(theTarget.PlayerDamage(finalResult));
                    damageResult += $" {theTarget.characterStats.CharacterName} took {finalResult} damage!";
                    break;
                }
            case AttackType.MAGICAL:
                {
                    damageOutput = (attacker.characterStats.CurrentMagic * move.AttackPower) / (2 * Math.Max(1, theTarget.characterStats.CurrentResistance));
                    finalResult = (int)Math.Ceiling(damageOutput);

                    if (finalResult <= 0)
                    {
                        if (move.MoveType != MoveType.SUPPLEMENTARY)
                        {
                            finalResult += 1;
                        }
                    }
                    //theTarget.TakeDamage(finalResult);
                    StartCoroutine(theTarget.PlayerDamage(finalResult));
                    damageResult += $" {theTarget.characterStats.CharacterName} took {finalResult} damage!";
                    break;
                }
        }

        if(move.BuffTypes.Length > 0)
        {
            //the attacker applies the buff on whatever ally- be it themselves or someone else
            theTarget.ApplyandDebuff(move.BuffTypes, move.BuffAmount);

            //adding the buffs to the message
            message += $" {theTarget.characterStats.CharacterName}'s";
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
            theTarget.ApplyandDebuff(move.DebuffTypes, move.DebuffAmount);

            message += $" {theTarget.characterStats.CharacterName}'s";

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

        if (theTarget.isDefeated)
        {
            damageResult += $" {theTarget.characterStats.CharacterName} was defeated!";
        }
    }

    public void CalcTool(Unit attacker, ItemObject item, Unit theTarget)
    {
        message += $"{attacker.characterStats.CharacterName} used {item.ItemName} on {theTarget.characterStats.CharacterName}!";

        switch (item.Type)
        {
            case ItemType.Health: 
                {
                    int hpRestorationAmount = 0;
                    int mpRestorationAmount = 0;

                    //making the item type more specifically a healing object
                    HealthObject healingItem = (HealthObject)item;

                    if (healingItem.hpRestoreAmount > 0)
                    {
                        hpRestorationAmount = (int)Math.Ceiling(healingItem.hpRestoreAmount + (.15f * attacker.characterStats.CurrentEfficiency));
                        theTarget.ApplyHealing(healingItem, hpRestorationAmount);
                        damageResult += $" Restored {hpRestorationAmount} health!";
                    }

                    if(healingItem.mpRestoreAmount > 0)
                    {
                        mpRestorationAmount = (int)Math.Ceiling(healingItem.mpRestoreAmount + (.15f * attacker.characterStats.CurrentEfficiency));
                        theTarget.ApplyHealing(healingItem, mpRestorationAmount);
                        damageResult += $" Restored {mpRestorationAmount} magic!";
                    }

                    break;
                }
            case ItemType.DamagingTool: 
                {
                    float damageOutput = 0f;

                    DamagingToolObject tool = (DamagingToolObject)item;
                    if (tool.atkPower > 0)
                    {
                        damageOutput = tool.atkPower + (.15f * attacker.characterStats.CurrentEfficiency);
                    }
                    else if(tool.magPower > 0)
                    {
                        damageOutput = tool.magPower + (.15f * attacker.characterStats.CurrentEfficiency);
                    }

                    finalResult = (int)Math.Ceiling(damageOutput);
                    //theTarget.TakeDamage(finalResult);
                    StartCoroutine(theTarget.PlayerDamage(finalResult));
                    damageResult += $" {theTarget.characterStats.CharacterName} took {finalResult} damage!";
                    break; 
                }

        }

        if (theTarget.isDefeated)
        {
            Debug.Log($"{theTarget.characterStats.CharacterName} was defeated!");
        }
    }
}

