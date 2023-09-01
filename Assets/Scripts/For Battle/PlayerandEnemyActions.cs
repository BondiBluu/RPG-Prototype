using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerandEnemyActions : MonoBehaviour
{

    public List<SavePlayerActions> playerActionContainer = new List<SavePlayerActions>();
    public List<SaveEnemyActions> enemyActionContainer = new List<SaveEnemyActions>();

    //saving player actions (attack, debuff, buff, etc)
    public void SavePlayersActions(Unit _playerUnit, MoveBaseClass _move, Unit _theTarget)
    {
        //adding the player's actions
        playerActionContainer.Add(new SavePlayerActions(_playerUnit, _move, _theTarget));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.CharacterName + " " + _move.AttackName + ", on " + _theTarget.characterStats.CharacterName);
    }

    //saving player item usage
    public void SaveItemUsage(Unit _playerUnit, ItemObject _item, Unit _theTarget)
    {
        playerActionContainer.Add(new SavePlayerActions(_playerUnit, _item, _theTarget));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.CharacterName + " " + _item.ItemName + ", on " + _theTarget.characterStats.CharacterName);
    }

    //saving enemy actions
    public void SaveEnemyAction(Unit _enemyUnit, MoveBaseClass _move, Unit _theTarget)
    {
        enemyActionContainer.Add(new SaveEnemyActions(_enemyUnit, _move, _theTarget));
        Debug.Log(enemyActionContainer.Count);
        Debug.Log(_enemyUnit.characterStats.CharacterName + " " + _move.AttackName + ", on " + _theTarget.characterStats.CharacterName);
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
        public Unit theTarget;
        public MoveBaseClass move;

        //saving enemy attacks and debuffs
        public SaveEnemyActions(Unit _enemyUnit, MoveBaseClass _move, Unit _theTarget)
        {
            enemyUnit = _enemyUnit;
            move = _move;
            theTarget = _theTarget;
        }
    }
}
