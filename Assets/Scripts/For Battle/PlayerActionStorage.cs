using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionStorage : MonoBehaviour
{
    
    List<PlayerActions> playerActionContainer = new List<PlayerActions> ();

    public void SavePlayerAction(Unit _playerUnit, MoveBaseClass _move)
    {
        //adding the player's actions
        playerActionContainer.Add(new PlayerActions(_playerUnit, _move));
        Debug.Log(playerActionContainer.Count);
        Debug.Log(_playerUnit.characterStats.characterName + " " + _move.AttackName);
    }


    //creating a class to store each player's actions
    class PlayerActions
    {
        public MoveBaseClass move;
        public Unit playerUnit;
        

        public PlayerActions(Unit _playerUnit, MoveBaseClass _move)
        {
            playerUnit = _playerUnit;
            move = _move;
        }
    }
}
