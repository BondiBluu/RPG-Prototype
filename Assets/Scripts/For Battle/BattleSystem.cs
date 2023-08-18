using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WIN,
    LOSS
}

public class BattleSystem : MonoBehaviour
{

    public BattleState state;
    BattleHUD playerHUD;
    BattleHUD enemyHUD;

    [Header ("Players and Stations")]
    public GameObject[] playerPrefabs;
    public Transform[] playerStations;
    Unit[] playerUnits;


    [Header("Enemies and Stations")]

    public GameObject[] enemyPrefabs;
    public Transform[] enemyStations;
    EnemyUnit[] enemyUnits;

    MoveGenerator moveGenerator;
    PlayerActionStorage playerActionStorage;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        playerHUD = FindObjectOfType<BattleHUD>();
        enemyHUD = FindObjectOfType<BattleHUD>();

        moveGenerator = FindObjectOfType<MoveGenerator>();
        playerActionStorage = FindObjectOfType<PlayerActionStorage>();

        //setting up the battle. Starting a Coroutine to manipulate time (waiting for seconds)
        StartCoroutine(SetUpBattle());
    }

    //instantiating our units. IEnumerator needed whenever a method is called for a coroutine
    IEnumerator SetUpBattle()
    {
        //instantiating all the playerUnits so it can be used with the appropriate size before the loop. It's not public after all, so how would it know?
        playerUnits = new Unit[playerPrefabs.Length];
        //saving the players to use later
        //instantiatedPlayers.Add(playerUnits);

        //looping instead of making 4 enemy references
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            //need a single transform since we can't use transform[] with Intsantiate(), so spawnStation will hold multiple playerStations
            Transform spawnStation = playerStations[i];

            //spawning our characters on the battle stations whle also making a reference to the spawning game object (used later)
            GameObject playerGObject = Instantiate(playerPrefabs[i], spawnStation);

            //using the reference to be able to get the stats information from each individual unit. storing the reference in a Unit and EnemyUnit var to use multiple times
            playerUnits[i] = playerGObject.GetComponent<Unit>();
        }
        playerHUD.SetPlayerHUD(playerUnits);

        enemyUnits = new EnemyUnit[enemyPrefabs.Length];
        //same for enemies
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Transform enemySpawnStation = enemyStations[i];
            GameObject enemyGObject = Instantiate(enemyPrefabs[i], enemySpawnStation);
            enemyUnits[i] = enemyGObject.GetComponent<EnemyUnit>();
        }
        enemyHUD.SetEnemyHUD(enemyUnits);


        //waiting seconds after everything has instantiated to switch turns
        yield return new WaitForSeconds(1f);

        
        //switching turns
        state = BattleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());
    }

    //where player can choose an action
    IEnumerator PlayerTurn()
    {
       for (int i = 0; i < playerUnits.Length; i++)
        {
            //showing the player's turn
            Debug.Log(playerUnits[i].characterStats.characterName + "'s turn.");
            //Debug.Log(playerUnits[i].characterStats);


            //display the attack button for the current unit
            moveGenerator.GenerateATKButtons(playerUnits[i].characterStats);
            moveGenerator.GenerateSUPPButtons(playerUnits[i].characterStats);

            //seeing if attackButtonPressed is true, meaning the player pressed the attack button
            yield return new WaitUntil(() => moveGenerator.HasPressedAttackButton());


            SavePlayerAction(playerUnits[i], moveGenerator.selectedMove);

            //saying the next player hasn't chosen their move yet.
            moveGenerator.ClearAttackButtons();
            
        }
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Finished.");
        //state = BattleState.ENEMYTURN;
    }

    List<PlayerActions> playerActionContainer = new List<PlayerActions>();

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



/*

    public IEnumerator PlayerAttack()
    {
        //damaging enemy
        //enemyUnits[0].TakeDamage(moveBaseClass.AttackPower);

        //waiting
        yield return new WaitForSeconds(2f);

        //check if enemy is dead
        //change state based on what's happened
    }

    public void TakeDamage()
    {

    }
    public void OnHealButton() { }*/