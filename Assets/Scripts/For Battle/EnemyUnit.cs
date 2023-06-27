using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    [SerializeField]public  EnemyStatistics enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats = FindObjectOfType<EnemyStatistics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
