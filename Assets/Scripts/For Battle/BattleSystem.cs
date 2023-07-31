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
    MoveBaseClass moveBaseClass;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        playerHUD = FindObjectOfType<BattleHUD>();
        enemyHUD = FindObjectOfType<BattleHUD>();

        moveBaseClass = FindObjectOfType<MoveBaseClass>();
        moveGenerator = FindObjectOfType<MoveGenerator>();

        //setting up the battle. Starting a Coroutine to manipulate time (waiting for seconds)
        StartCoroutine(SetUpBattle());
    }

    //instantiating our units. IEnumerator needed whenever a method is called for a coroutine
    IEnumerator SetUpBattle()
    {
        PlayersandEnemiesInstantiate();

        //waiting seconds after everything has instantiated to switch turns
        yield return new WaitForSeconds(2f);

        //switching turns
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void PlayersandEnemiesInstantiate()
    {
        //instantiating playerUnits so it can be used with the appropriate size before the loop. It's not public after all, so how would it know?
        playerUnits = new Unit[playerPrefabs.Length];

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
    }

    //where player can choose an action
    void PlayerTurn()
    {
        //selected player being the variable that stores the current player's CharaStats data
        //moveGenerator.SetCharacterData(selectedPlayer);
    }

    public void OnAttackButton() {

        //don't do anything if it's not the player's turn
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        //damaging enemy

        //waiting
        yield return new WaitForSeconds(1);

        //check if enemy is dead
        //change state based on what's happened
    }

    void TakeDamage()
    {

    }
    public void OnHealButton() { }

}
