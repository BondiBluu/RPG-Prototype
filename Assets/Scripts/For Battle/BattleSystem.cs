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
    public Unit selectedPlayerUnit;


    [Header("Enemies and Stations")]

    public GameObject[] enemyPrefabs;
    public Transform[] enemyStations;
    Unit[] enemyUnits;
    public Unit selectedEnemy; //for the player to choose which enemy to hits

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
            Debug.Log(playerUnits[i].characterStats.CharacterName + "'s turn.");

            //display the attack etc buttons for the current unit
            moveGenerator.GenerateATKButtons(playerUnits[i].characterStats);
            moveGenerator.GenerateSUPPButtons(playerUnits[i].characterStats);
            moveGenerator.GenerateItems();

            //seeing if attackButtonPressed is true, meaning the player pressed the attack button
            yield return new WaitUntil(() => moveGenerator.HasPressedAttackButton());

            //checking if they've opened the attck button to click an attack
            if (attackandSupplementary.wantsToAttack == true)
            {

                //if the move selected is a buff
                if (moveGenerator.selectedMove.BuffTypes.Length > 0)
                {
                    attackandSupplementary.AllyContainerOn();

                    yield return new WaitUntil(() => selectedPlayerUnit != null);

                    playerandEnemyStorage.SavePlayersActions(playerUnits[i], moveGenerator.selectedMove, selectedPlayerUnit);

                    attackandSupplementary.allyPanelUI.SetActive(false);
                }

                //if it's an attacking move or debuff
                if (moveGenerator.selectedMove.DebuffTypes.Length > 0 || moveGenerator.selectedMove.AttackPower > 0)
                {
                    attackandSupplementary.EnemyContainerOn();

                    yield return new WaitUntil(() => selectedEnemy != null);

                    playerandEnemyStorage.SavePlayersActions(playerUnits[i], moveGenerator.selectedMove, selectedEnemy);

                    attackandSupplementary.enemyPanelUI.SetActive(false);
                }
            }

            if (attackandSupplementary.wantsToUseItem == true)
            {

                if (moveGenerator.selectedItem.Type == ItemType.Health)
                {
                    attackandSupplementary.AllyContainerOn();
                    yield return new WaitUntil(() => selectedPlayerUnit != null);
                    playerandEnemyStorage.SaveItemUsage(playerUnits[i], moveGenerator.selectedItem, selectedPlayerUnit);
                    attackandSupplementary.allyPanelUI.SetActive(false);
                }

                if (moveGenerator.selectedItem.Type == ItemType.DamagingTool)
                {
                    attackandSupplementary.EnemyContainerOn();
                    yield return new WaitUntil(() => selectedEnemy != null);
                    playerandEnemyStorage.SaveItemUsage(playerUnits[i], moveGenerator.selectedItem, selectedEnemy);
                    attackandSupplementary.enemyPanelUI.SetActive(false);
                }
            }

            selectedPlayerUnit = null;
            selectedEnemy = null;
            attackandSupplementary.enemyPanelUI.SetActive(false);
            attackandSupplementary.allyPanelUI.SetActive(false);
            //saying the next player hasn't chosen their move yet.
            moveGenerator.ClearAttackButtons();
        }
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Finished.");
        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    //picking a target ally (for Unity hierarchy)
    public void OnPlayerClick(int playerIndex)
    {
        //selecter player will be the button linked to the unit. Unit will then be chosen at the selected player to recieve buffs ot heals
        selectedPlayerUnit = playerUnits[playerIndex];
        selectedPlayerIndex++;
    }

    //for button clicking enemies (for Unity hierarchy)
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
            int enemyMoves = enemyUnits[i].characterStats.moveBaseClassList.Count;
            int playersPresent = playerUnits.Length;
            int selectedPlayer = Random.Range(0, playersPresent);
            //enemy will choosea random move in their list
            int selectedMove = Random.Range(0, enemyMoves);
            //move to use is whatever number was chosen
            MoveBaseClass moveToUse = enemyUnits[i].characterStats.moveBaseClassList[selectedMove];
            Unit unitToAttack = playerUnits[selectedPlayer];

            playerandEnemyStorage.SaveEnemyAction(enemyUnits[i], moveToUse, unitToAttack);
        }
        state = BattleState.BATTLEPHASE;
        StartCoroutine(BattlePhase());
    }



    IEnumerator BattlePhase()
    {
        //saving 2 separate lists of player and enemy actions
        List<PlayerandEnemyActions.SavePlayerActions> sortedPlayerActions = playerandEnemyStorage.playerActionContainer.OrderByDescending(action => action.playerUnit.characterStats.CurrentSpeed).ToList();    
        List<PlayerandEnemyActions.SaveEnemyActions> sortedEnemyActions = playerandEnemyStorage.enemyActionContainer.OrderByDescending(action => action.enemyUnit.characterStats.CurrentSpeed).ToList();

            List<object> allActions = new List<object>();

            //adding all sorted actions to allActions
            allActions.AddRange(sortedPlayerActions);
            allActions.AddRange(sortedEnemyActions);

            //sorting all actions by way of speed
            allActions.Sort((action1, action2) =>
            {
                float speed1 = 0f;
                float speed2 = 0f;

                if (action1 is PlayerandEnemyActions.SavePlayerActions playerActions1)
                {
                    speed1 = playerActions1.playerUnit.characterStats.CurrentSpeed;
                }
                else if (action1 is PlayerandEnemyActions.SaveEnemyActions enemyActions1)
                {
                    speed1 = enemyActions1.enemyUnit.characterStats.CurrentSpeed;
                }

                if (action2 is PlayerandEnemyActions.SavePlayerActions playerActions2)
                {
                    speed2 = playerActions2.playerUnit.characterStats.CurrentSpeed;
                }
                else if (action2 is PlayerandEnemyActions.SaveEnemyActions enemyActions2)
                {
                    speed2 = enemyActions2.enemyUnit.characterStats.CurrentSpeed;
                }

                return speed2.CompareTo(speed1);
            });


        //displaying all character actions NOTE: when using anims, yield return new WaitForSeconds(animClip.length) 
        foreach (object action in allActions)
            {
            if (action is PlayerandEnemyActions.SavePlayerActions playerAction)
                {
                if(playerAction.move != null)
                {
                    int damage = damageCalc.CalcDamage(playerAction.playerUnit, playerAction.move, playerAction.theTarget);
                    string message = damageCalc.message;
                    Debug.Log(message);
                    damageCalc.message = "";
                } 
                else if (playerAction.item != null)
                {
                    damageCalc.CalcTool(playerAction.playerUnit, playerAction.item, playerAction.theTarget);
                    string message = damageCalc.message;
                    Debug.Log(message);
                    damageCalc.message = "";
                }
                
                }
    
            else if (action is PlayerandEnemyActions.SaveEnemyActions enemyAction)
                {    
                int damage = damageCalc.CalcDamage(enemyAction.enemyUnit, enemyAction.move, enemyAction.theTarget);
                string message = damageCalc.message;
                Debug.Log(message);
                damageCalc.message = "";
            }

            yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(2f);
            Debug.Log("Finished");
        }        
    }