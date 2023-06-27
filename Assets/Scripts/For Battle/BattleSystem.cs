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
    BattleHUD battleHUD;

    [Header ("Players and Stations")]
    public GameObject[] playerPrefabs;
    public Transform[] playerStations;
    Unit[] playerUnits;


    [Header("Enemies and Stations")]

    public GameObject[] enemyPrefabs;
    public Transform[] enemyStations;
    EnemyUnit[] enemyUnits;


    Unit playerUnit1;
    Unit playerUnit2;
    Unit playerUnit3;
    Unit playerUnit4;
    EnemyUnit enemyUnit1;
    EnemyUnit enemyUnit2;
    EnemyUnit enemyUnit3;
    EnemyUnit enemyUnit4;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        battleHUD = FindObjectOfType<BattleHUD>();

        //setting up the battle
        SetUpBattle();
    }

    //instantiating our units
    void SetUpBattle()
    {

        PlayersandEnemiesInstantiate();
    }

    public void PlayersandEnemiesInstantiate()
    {
        //instantiating playerUnits so it can be used with the appropriate size before the loop. It's not public after all, so how would it know?
        playerUnits = new Unit[playerPrefabs.Length];
        //GameObject[] playerGObjects;
        //playerGObjects = new GameObject[playerPrefabs.Length];
        //looping instead of making 4 enemy references
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            //need a single transform since we can't use transform[] with Intsantiate(), so spawnStation will hold multiple playerStations
            Transform spawnStation = playerStations[i];

            //spawning our characters on the battle stations whle also making a reference to the spawning game object (used later)
            GameObject playerGObject = Instantiate(playerPrefabs[i], spawnStation);
            //playerGObjects[i] = Instantiate(playerPrefabs[i], spawnStation);
            //using the reference to be able to get the stats information from each individual unit. storing the reference in a Unit and EnemyUnit var to use multiple times
            playerUnits[i] = playerGObject.GetComponent<Unit>();
        }
        battleHUD.SetPlayerHUD(playerUnits);

        enemyUnits = new EnemyUnit[enemyPrefabs.Length];
        //same for enemies
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Transform enemySpawnStation = enemyStations[i];
            GameObject enemyGObject = Instantiate(enemyPrefabs[i], enemySpawnStation);
            enemyUnits[i] = enemyGObject.GetComponent<EnemyUnit>();
        }
    }

}
