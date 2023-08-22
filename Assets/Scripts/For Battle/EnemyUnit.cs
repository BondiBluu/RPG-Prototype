using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField] public EnemyStatistics enemyStats;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakingDamage()
    {
        bool isDefeated;
        if (enemyStats.currentHP <= 0)
        {
            isDefeated = true;
        }
    }
}
