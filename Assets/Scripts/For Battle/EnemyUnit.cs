using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{

    public void ApplyDebuff(Boost[] debuffTypes, float debuffAmount)
    {
        foreach (Boost debuffType in debuffTypes)
        {
            switch (debuffType)
            {
                case Boost.ATTACK:
                    {
                        break;
                    }
                case Boost.DEFENSE:
                    {
                        break;
                    }
                case Boost.MAGIC:
                    {
                        break;
                    }
                case Boost.RES:
                    {
                        break;
                    }
                case Boost.EFF:
                    {
                        break;
                    }
                case Boost.SKILL:
                    {
                        break;
                    }
                case Boost.SPEED:
                    {
                        break;
                    }
            }
        }
    }
}
/* void TakeDamage()
    {
        bool isDefeated;
        if (enemyStats.CurrentHP <= 0)
        {
            isDefeated = true;
        }
    }*/
