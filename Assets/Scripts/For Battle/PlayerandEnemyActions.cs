using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerandEnemyActions : MonoBehaviour
{

    public List<PlayerActions> playerActionContainer = new List<PlayerActions>();
    public List<EnemyActions> enemyActionContainer = new List<EnemyActions>();

    public void SavePlayerAction(Unit _playerUnit, MoveBaseClass _move, EnemyUnit _enemyUnit)
    {
        //adding the player's actions
        playerActionContainer.Add(new PlayerActions(_playerUnit, _move, _enemyUnit));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.characterName + " " + _move.AttackName + ", on " + _enemyUnit.enemyStats.enemyName);
    }
    public void SaveEnemyAction(EnemyUnit _enemyUnit, MoveBaseClass _move, Unit _playerUnit)
    {
        //adding the player's actions
        enemyActionContainer.Add(new EnemyActions(_enemyUnit, _move, _playerUnit));
        Debug.Log(enemyActionContainer.Count);
        Debug.Log(_enemyUnit.enemyStats.enemyName + " " + _move.AttackName + ", on " + _playerUnit.characterStats.characterName);
    }


    //creating a class to store each player's actions
    public class PlayerActions
    {
        public MoveBaseClass move;
        public Unit playerUnit;
        public EnemyUnit enemyTarget;

        public PlayerActions(Unit _playerUnit, MoveBaseClass _move, EnemyUnit _enemyUnit)
        {
            playerUnit = _playerUnit;
            move = _move;
            enemyTarget = _enemyUnit;
        }

    }
    public class EnemyActions
    {
        public MoveBaseClass move;
        public EnemyUnit enemyUnit;
        public Unit playerTarget;


        public EnemyActions(EnemyUnit _enemyUnit, MoveBaseClass _move, Unit _playerUnit)
        {
            enemyUnit = _enemyUnit;
            move = _move;
            playerTarget = _playerUnit;
        }
    }
}
