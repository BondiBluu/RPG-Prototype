using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public CharacterStatistics characterStats;
    MoveBaseClass moveBaseClass;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
