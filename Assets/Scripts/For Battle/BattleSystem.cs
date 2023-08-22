using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    BATTLEPHASE,
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
    public EnemyUnit selectedEnemy; //for the player to choose which enemy to hits

    [Header("Buttons")]
    public Button[] enemySelectButton;

    int selectedPlayerIndex = 0;

    MoveGenerator moveGenerator;
    AttackandSupplementary attackandSupplementary;
    PlayerActionStorage playerActionStorage;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        playerHUD = FindObjectOfType<BattleHUD>();
        enemyHUD = FindObjectOfType<BattleHUD>();

        moveGenerator = FindObjectOfType<MoveGenerator>();
        playerActionStorage = FindObjectOfType<PlayerActionStorage>();
        attackandSupplementary = FindObjectOfType<AttackandSupplementary>();

        //setting up the battle. Starting a Coroutine to manipulate time (waiting for seconds)
        StartCoroutine(SetUpBattle());
    }

    //instantiating our units. IEnumerator needed whenever a method is called for a coroutine
    IEnumerator SetUpBattle()
    {
        //instantiating all the playerUnits so it can be used with the appropriate size before the loop. It's not public after all, so how would it know?
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

            //display the attack etc buttons for the current unit
            moveGenerator.GenerateATKButtons(playerUnits[i].characterStats);
            moveGenerator.GenerateSUPPButtons(playerUnits[i].characterStats);

            

            //seeing if attackButtonPressed is true, meaning the player pressed the attack button
            yield return new WaitUntil(() => moveGenerator.HasPressedAttackButton());

            attackandSupplementary.EnemyContainerOn();

            yield return new WaitUntil(() => selectedEnemy != null);

            SavePlayerAction(playerUnits[i], moveGenerator.selectedMove, selectedEnemy);

            selectedEnemy = null;
            attackandSupplementary.enemyPanelUI.SetActive(false);
            //saying the next player hasn't chosen their move yet.
            moveGenerator.ClearAttackButtons();
        }
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Finished.");
        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    //for button clicking enemies
    public void OnEnemyButtonClick(int enemyIndex)
    {
        selectedEnemy = enemyUnits[enemyIndex];
        selectedPlayerIndex++;
    }




    void EnemyTurn()
    {
        //wat for the enemy to move
        for(int i = 0; i < enemyUnits.Length; i++)
        {
            //getting how many enemy moves there are in the current enemy
            int enemyMoves = enemyUnits[i].enemyStats.moveBaseClassList.Count;
            int playersPresent = playerUnits.Length;
            int selectedPlayer = Random.Range(0, playersPresent);
            //enemy will choosea random move in their list
            int selectedMove = Random.Range(0, enemyMoves);
            //move to use is whatever number was chosen
            MoveBaseClass moveToUse = enemyUnits[i].enemyStats.moveBaseClassList[selectedMove];
            Unit unitToAttack = playerUnits[selectedPlayer];

            SaveEnemyAction(enemyUnits[i], moveToUse, unitToAttack);
        }
        state = BattleState.BATTLEPHASE;
    }

    List<PlayerActions> playerActionContainer = new List<PlayerActions>();
    List<EnemyActions> enemyActionContainer = new List<EnemyActions>();

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
    class PlayerActions
    {
        public MoveBaseClass move;
        public Unit playerUnit;
        public EnemyUnit enemyUnit;

        public PlayerActions(Unit _playerUnit, MoveBaseClass _move, EnemyUnit _enemyUnit)
        {
            playerUnit = _playerUnit;
            move = _move;
            enemyUnit = _enemyUnit;
        }

    }
    class EnemyActions
    {
        public MoveBaseClass move;
        public EnemyUnit enemyUnit;
        public Unit playerUnit;


        public EnemyActions(EnemyUnit _enemyUnit, MoveBaseClass _move, Unit _playerUnit)
        {
            enemyUnit = _enemyUnit;
            move = _move;
            playerUnit = _playerUnit;
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