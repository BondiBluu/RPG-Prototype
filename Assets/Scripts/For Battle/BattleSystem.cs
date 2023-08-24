using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

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

    [Header("Players and Stations")]
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
    DamageCalc damageCalc;
    PlayerandEnemyActions playerandEnemyStorage;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        playerHUD = FindObjectOfType<BattleHUD>();
        enemyHUD = FindObjectOfType<BattleHUD>();

        moveGenerator = FindObjectOfType<MoveGenerator>();
        playerandEnemyStorage = FindObjectOfType<PlayerandEnemyActions>();
        attackandSupplementary = FindObjectOfType<AttackandSupplementary>();
        damageCalc = FindObjectOfType<DamageCalc>();

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

            playerandEnemyStorage.SavePlayerAction(playerUnits[i], moveGenerator.selectedMove, selectedEnemy);

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
        for (int i = 0; i < enemyUnits.Length; i++)
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

            playerandEnemyStorage.SaveEnemyAction(enemyUnits[i], moveToUse, unitToAttack);
        }
        state = BattleState.BATTLEPHASE;
        StartCoroutine(BattlePhase());
    }



    IEnumerator BattlePhase()
    {
        List<PlayerandEnemyActions.PlayerActions> sortedPlayerActions = playerandEnemyStorage.playerActionContainer.OrderByDescending(action => action.playerUnit.characterStats.speed).ToList();
        List<PlayerandEnemyActions.EnemyActions> sortedEnemyActions = playerandEnemyStorage.enemyActionContainer.OrderByDescending(action => action.enemyUnit.enemyStats.speed).ToList();

        List<object> allActions = new List<object>();

        //adding all sorted actions to allActions
        allActions.AddRange(sortedPlayerActions);
        allActions.AddRange(sortedEnemyActions);

        //sorting all actions by way of speed
        allActions.Sort((action1, action2) =>
        {
            float speed1 = 0f;
            float speed2 = 0f;

            if (action1 is PlayerandEnemyActions.PlayerActions playerActions1)
            {
                speed1 = playerActions1.playerUnit.characterStats.speed;
            }
            else if (action1 is PlayerandEnemyActions.EnemyActions enemyActions1)
            {
                speed1 = enemyActions1.enemyUnit.enemyStats.speed;
            }

            if (action2 is PlayerandEnemyActions.PlayerActions playerActions2)
            {
                speed2 = playerActions2.playerUnit.characterStats.speed;
            }
            else if (action2 is PlayerandEnemyActions.EnemyActions enemyActions2)
            {
                speed2 = enemyActions2.enemyUnit.enemyStats.speed;
            }

            return speed2.CompareTo(speed1);
        });

        //displaying all character actions NOTE: when using anims, yield return new WaitForSeconds(animClip.length)
        foreach (object action in allActions)
        {

            if (action is PlayerandEnemyActions.PlayerActions playerAction)
            {

                int damage = damageCalc.CalcDamage(playerAction.playerUnit, playerAction.move, playerAction.enemyTarget);
                Debug.Log(playerAction.playerUnit.characterStats.characterName + " uses " + playerAction.move.AttackName + " on " + playerAction.enemyTarget.enemyStats.enemyName + "! Does "
                    + damage + " damage!");
            }

            else if (action is PlayerandEnemyActions.EnemyActions enemyAction)
            {
                int damage = damageCalc.EnemyCalc(enemyAction.enemyUnit, enemyAction.move, enemyAction.playerTarget);
                Debug.Log(enemyAction.enemyUnit.enemyStats.enemyName + " uses " + enemyAction.move.AttackName + " on " + enemyAction.playerTarget.characterStats.characterName + "! Does "
                    + damage + " damage!");
            }

            yield return new WaitForSeconds(2f);
        }

        yield return new WaitForSeconds(2f);
        Debug.Log("Finished");
    }

    //NOTE to make damage calcs based on the enemy's resistances, player's attack power, and move's base class attack power. int CalcDamage(Unit attacker, MoveBaseClass move, EnemyUnit target)
    int CalcDamage(MoveBaseClass moveToDamage)
    {

        int damage = moveToDamage.AttackPower;
        return damage;
    }
}