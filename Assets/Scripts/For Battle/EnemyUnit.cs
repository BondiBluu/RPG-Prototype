using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] public EnemyStatistics enemyStats;

    void TakeDamage()
    {
        bool isDefeated;
        if (enemyStats.currentHP <= 0)
        {
            isDefeated = true;
        }
    }
}
