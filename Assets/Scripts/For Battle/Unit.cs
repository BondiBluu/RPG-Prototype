using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public CharacterStatistics characterStats;
    BattleHUD battleHUD;
   
    public bool isDefeated;

    private void Start()
    {
        battleHUD = FindObjectOfType<BattleHUD>();
        isDefeated = false;
        RemoveBuffsAndDebuffs();
    }

    //for testing purposes ONLY
    public void InitialiseStats()
    {
        characterStats.CurrentHP = characterStats.MaxHP;
        characterStats.CurrentMP = characterStats.MaxMP;
    }

    public IEnumerator TakeDamage(int finalResult)
    {
        float originalHP = characterStats.CurrentHP;

        while(characterStats.CurrentHP > originalHP - finalResult){
            characterStats.CurrentHP -= 1;
            UpdateHealthAndMagic();
            yield return new WaitForSeconds(0.05f);

            if (characterStats.CurrentHP <= 0)
            {
                characterStats.CurrentHP = 0;
                isDefeated = true;
            }
            else
            {
                isDefeated = false;
            }
        }
    }
    
    public IEnumerator TakeMP(int mpConsumption)
    {
        float originalMP = characterStats.CurrentMP;

        while (characterStats.CurrentMP > originalMP - mpConsumption)
        {
            characterStats.CurrentMP -= 1;
            UpdateHealthAndMagic();
            yield return new WaitForSeconds(0.05f);
        }
    }


    public IEnumerator ApplyHealing(HealthObject item, int finalResult)
    {
        float originalHP = characterStats.CurrentHP;
        float originalMP = characterStats.CurrentMP;

        if(item.hpRestoreAmount > 0)
        {

            while (characterStats.CurrentHP < originalHP + finalResult)
            {
                characterStats.CurrentHP += 1;
                UpdateHealthAndMagic();
                yield return new WaitForSeconds(0.05f);

                if (characterStats.CurrentHP >= characterStats.MaxHP)
                {
                    characterStats.CurrentHP = characterStats.MaxHP;

                    break;
                }
            }
        } 
        else if (item.mpRestoreAmount > 0)
        {

            while (characterStats.CurrentMP < originalMP + finalResult)
            {
                characterStats.CurrentMP += 1;
                UpdateHealthAndMagic();
                yield return new WaitForSeconds(0.05f);

                if (characterStats.CurrentMP >= characterStats.MaxMP)
                {
                    characterStats.CurrentMP = characterStats.MaxMP;

                    break;
                }
            }
        }
        
    }

    public void UpdateHealthAndMagic()
    {
        if(characterStats.UnitType == UnitType.PLAYERCHARACTER)
        {
            battleHUD.UpdatePlayerHPAndMP(this, characterStats.CurrentHP, characterStats.MaxHP, characterStats.CurrentMP, characterStats.MaxMP);
        } 
        else
        {
            battleHUD.UpdateEnemyHPAndMP(this, characterStats.CurrentHP);
        }
    }

    int minAttack;
    int minMagic;
    int minDef;
    int minRes;
    int minEff;
    int minSkill;
    int minSpeed;
    int maxAttack;
    int maxMagic;
    int maxDef;
    int maxRes;
    int maxEff;
    int maxSkill;
    int maxSpeed;

    public void ApplyandDebuff(Boost[] boostTypes, float boostAmount)
    {
        foreach(Boost boostType in boostTypes)
        {
            switch(boostType)
            {
                case Boost.ATTACK:
                    {
                        characterStats.CurrentAttack += (int)(characterStats.BaseAttack * boostAmount);
                        break;
                    }   
                case Boost.DEFENSE: 
                    {
                        characterStats.CurrentDefense += (int)(characterStats.BaseDefense * boostAmount);
                        break; 
                    }    
                case Boost.MAGIC: 
                    {
                        characterStats.CurrentMagic += (int)(characterStats.BaseMagic * boostAmount);
                        break; 
                    }    
                case Boost.RES: 
                    {
                        characterStats.CurrentResistance += (int)(characterStats.BaseResistance * boostAmount);
                        break; 
                    }
                case Boost.EFF: 
                    {
                        characterStats.CurrentEfficiency += (int)(characterStats.BaseEfficiency * boostAmount);
                        break;
                    }   
                case Boost.SKILL: 
                    {
                        characterStats.CurrentSkill += (int)(characterStats.BaseSkill * boostAmount);
                        break;
                    }    
                case Boost.SPEED: 
                    {
                        characterStats.CurrentSpeed += (int)(characterStats.BaseSpeed * boostAmount);
                        break;
                    }
            }
        }
    }

    public void RemoveBuffsAndDebuffs()
    {
        characterStats.CurrentAttack = characterStats.BaseAttack;
        characterStats.CurrentMagic = characterStats.BaseMagic;
        characterStats.CurrentDefense = characterStats.BaseDefense;
        characterStats.CurrentResistance = characterStats.BaseResistance;
        characterStats.CurrentEfficiency = characterStats.BaseEfficiency;
        characterStats.CurrentSkill = characterStats.BaseSkill;
        characterStats.CurrentSpeed = characterStats.BaseSpeed;
    }
}


