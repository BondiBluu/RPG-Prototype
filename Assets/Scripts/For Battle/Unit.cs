using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public CharacterStatistics characterStats;
    MoveBaseClass moveBaseClass;

    void TakingDamage()
    {
        bool isDefeated;
        if (characterStats.currentHP <= 0)
        {
            isDefeated = true;
        }
        isDefeated = false;
    }

    public bool TakeDamage()
    {
        characterStats.currentHP -= moveBaseClass.AttackPower;

        if(characterStats.currentHP <= 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
