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

    public void SaveItemUsage(Unit _playerUnit, ItemObject _item, Unit _theTarget)
    {
        playerActionContainer.Add(new SavePlayerActions(_playerUnit, _item, _theTarget));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.CharacterName + " " + _item.ItemName + ", on " + _theTarget.characterStats.CharacterName);
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

    public void SaveItems() { }



    public class SavePlayerActions
    {
        public MoveBaseClass move;
        public ItemObject item;
        public Unit playerUnit;
        public Unit theTarget;

        //saving player attacks and debuffs
        public SavePlayerActions(Unit _playerUnit, MoveBaseClass _move, Unit _theTarget)
        {
            playerUnit = _playerUnit;
            move = _move;
            theTarget = _theTarget;
        }

        public SavePlayerActions(Unit _playerUnit, ItemObject _item, Unit _theTarget)
        {
            playerUnit = _playerUnit;
            item = _item;
            theTarget = _theTarget;
        }
    }

    public class SaveEnemyActions
    {
        public Unit enemyUnit;
        public Unit playerTarget;
        public MoveBaseClass move;

        //saving enemy attacks and debuffs
        public SaveEnemyActions(Unit _enemyUnit, MoveBaseClass _move, Unit _playerUnit)
        {
            enemyUnit = _enemyUnit;
            move = _move;
            playerTarget = _playerUnit;
        }
    }
}
