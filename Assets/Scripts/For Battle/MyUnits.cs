using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] public CharacterStatistics characterStats;
    MoveBaseClass moveBaseClass;
    void TakingDamage()
    {
        bool isDefeated;
        if (characterStats.CurrentHP <= 0)
        {
            isDefeated = true;
        }
        isDefeated = false;
    }

    public bool TakeDamage()
    {
        characterStats.CurrentHP -= moveBaseClass.AttackPower;

        if (characterStats.CurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
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

    public void ApplyBuff(Boost[] buffTypes, float buffAmount)
    {
        foreach (Boost buffType in buffTypes)
        {
            switch (buffType)
            {
                case Boost.ATTACK:
                    {
                        characterStats.CurrentAttack += (int)(characterStats.BaseAttack * buffAmount);
                        break;
                    }
                case Boost.DEFENSE:
                    {
                        characterStats.CurrentDefense += (int)(characterStats.BaseDefense * buffAmount);
                        break;
                    }
                case Boost.MAGIC:
                    {
                        characterStats.CurrentMagic += (int)(characterStats.BaseMagic * buffAmount);
                        break;
                    }
                case Boost.RES:
                    {
                        characterStats.CurrentResistance += (int)(characterStats.BaseResistance * buffAmount);
                        break;
                    }
                case Boost.EFF:
                    {
                        characterStats.CurrentEfficiency += (int)(characterStats.BaseEfficiency * buffAmount);
                        break;
                    }
                case Boost.SKILL:
                    {
                        characterStats.CurrentSkill += (int)(characterStats.BaseSkill * buffAmount);
                        break;
                    }
                case Boost.SPEED:
                    {
                        characterStats.CurrentSpeed += (int)(characterStats.BaseSpeed * buffAmount);
                        break;
                    }
            }
        }
    }

    public void ApplyDeuff(Boost[] debuffTypes, float debuffAmount)
    {
        foreach (Boost debuffType in debuffTypes)
        {
            switch (debuffType)
            {
                case Boost.ATTACK:
                    {
                        characterStats.CurrentAttack += (int)(characterStats.BaseAttack * debuffAmount);
                        break;
                    }
                case Boost.DEFENSE:
                    {
                        characterStats.CurrentDefense += (int)(characterStats.BaseDefense * debuffAmount);
                        break;
                    }
                case Boost.MAGIC:
                    {
                        characterStats.CurrentMagic += (int)(characterStats.BaseMagic * debuffAmount);
                        break;
                    }
                case Boost.RES:
                    {
                        characterStats.CurrentResistance += (int)(characterStats.BaseResistance * debuffAmount);
                        break;
                    }
                case Boost.EFF:
                    {
                        characterStats.CurrentEfficiency += (int)(characterStats.BaseEfficiency * debuffAmount);
                        break;
                    }
                case Boost.SKILL:
                    {
                        characterStats.CurrentSkill += (int)(characterStats.BaseSkill * debuffAmount);
                        break;
                    }
                case Boost.SPEED:
                    {
                        characterStats.CurrentSpeed += (int)(characterStats.BaseSpeed * debuffAmount);
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

public class PlayerUnit : Units
{
    public PlayerStatistics characterStatistics;
}
public class EnemyUnits : Units
{
    public EnemyStatistic enemyStatistics;
}
