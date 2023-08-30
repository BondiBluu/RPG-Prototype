using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerandEnemyActions : MonoBehaviour
{

    public List<SavePlayerActions> playerActionContainer = new List<SavePlayerActions>();
    public List<SaveEnemyActions> enemyActionContainer = new List<SaveEnemyActions>();

    //saving player attack and defuffs
    public void SaveAttacksAndDebuffs(Unit _playerUnit, MoveBaseClass _move, Unit _enemyUnit)
    {
        //adding the player's actions
        playerActionContainer.Add(new SavePlayerActions(_playerUnit, _move, _enemyUnit));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.CharacterName + " " + _move.AttackName + ", on " + _enemyUnit.characterStats.CharacterName);
    }

    //saving player heals and buffs
    public void SaveBuffAndHeal(Unit _playerUnit, MoveBaseClass _move, Unit _allyTarget)
    {
        playerActionContainer.Add(new SavePlayerActions(_playerUnit, _move, _allyTarget));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.CharacterName + " " + _move.AttackName + ", on " + _allyTarget.characterStats.CharacterName);
    }

    //saving enemy attack and defuffs
    public void SaveEnemyAndDebuffs(Unit _enemyUnit, MoveBaseClass _move, Unit _playerUnit)
    {
        enemyActionContainer.Add(new SaveEnemyActions(_enemyUnit, _move, _playerUnit));
        Debug.Log(enemyActionContainer.Count);
        Debug.Log(_enemyUnit.characterStats.CharacterName + " " + _move.AttackName + ", on " + _playerUnit.characterStats.CharacterName);
    }

    //saving enemy heals and buffs
    public void SaveEnemyBuffAndHeal(Unit _enemyUnit, MoveBaseClass _move, Unit _alliedEnemyUnit)
    {
        enemyActionContainer.Add(new SaveEnemyActions(_enemyUnit, _move, _alliedEnemyUnit));
        Debug.Log(enemyActionContainer.Count);
        Debug.Log(_enemyUnit.characterStats.CharacterName + " " + _move.AttackName + ", on " + _alliedEnemyUnit.characterStats.CharacterName);
    }



    public class SavePlayerActions
    {
        public MoveBaseClass move;
        public Unit playerUnit;
        public Unit enemyTarget;
        public Unit allyTarget;


        //saving player attacks and debuffs
        public SavePlayerActions(Unit _playerUnit, MoveBaseClass _move, Unit _enemyUnit)
        {
            playerUnit = _playerUnit;
            move = _move;
            enemyTarget = _enemyUnit;
        }

/*        //saving player buffs and heals
        public SavePlayerActions(Unit _playerUnit, MoveBaseClass _move, Unit _allyTarget)
        {
            playerUnit = _playerUnit;
            move = _move;
            allyTarget = _allyTarget;
        }*/
    }

    public class SaveEnemyActions
    {
        public Unit enemyUnit;
        public Unit playerTarget;
        public Unit alliedEnemyTarget;
        public MoveBaseClass move;

        //saving enemy attacks and debuffs
        public SaveEnemyActions(Unit _enemyUnit, MoveBaseClass _move, Unit _playerUnit)
        {
            enemyUnit = _enemyUnit;
            move = _move;
            playerTarget = _playerUnit;
        }

        /*  //saving enemy buffs and heals
          public SaveEnemyActions(Unit _enemyUnit, MoveBaseClass _move, Unit _alliedEnemyUnit)
          {
              enemyUnit = _enemyUnit;
              move = _move;
              alliedEnemyTarget = _alliedEnemyUnit;
          }*/
    }
}
/*
 * public List<PlayerActions> playerActionContainer = new List<PlayerActions>();
    public List<PlayerSave> playerSaveContainer = new List<PlayerSave>();
    public List<EnemyActions> enemyActionContainer = new List<EnemyActions>();
    public List<EnemySave> enemySaveContainer = new List<EnemySave>();
 * 
    //creating a class to store each player's actions
    public class PlayerActions
    {
        public MoveBaseClass move;
        public Unit playerUnit;
        public EnemyUnit enemyTarget;
        Unit allyTarget;

        public PlayerActions(Unit _playerUnit, MoveBaseClass _move, EnemyUnit _enemyUnit)
        {
            playerUnit = _playerUnit;
            move = _move;
            enemyTarget = _enemyUnit;
        }

        public PlayerActions(Unit _playerUnit, MoveBaseClass _move, Unit _allyTarget)
        {
            playerUnit = _playerUnit;
            move = _move;
            allyTarget = _allyTarget;
        }

        

    }
    
    //creating a class to store each player's actions
    public class PlayerSave
    {
        public MoveBaseClass move;
        public Unit playerUnit;
        public Unit allyTarget;

        public PlayerSave(Unit _playerUnit, MoveBaseClass _move, Unit _allyTarget)
        {
            playerUnit = _playerUnit;
            move = _move;
            allyTarget = _allyTarget;
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
    
    public class EnemySave
    {
        public MoveBaseClass move;
        public EnemyUnit enemyUnit;
        public EnemyUnit alliedEnemyTarget;


        public EnemySave(EnemyUnit _enemyUnit, MoveBaseClass _move, EnemyUnit _alliedEnemyUnit)
        {
            enemyUnit = _enemyUnit;
            move = _move;
            alliedEnemyTarget = _alliedEnemyUnit;
        }
    }*/
