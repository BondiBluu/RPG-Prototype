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
    public Unit[] playerUnits;
    public Unit selectedPlayerUnit;
    int currentCycleIndex = 0;
    int currentStatsIndex = 0;

    [Header("Enemies and Stations")]

    public GameObject[] enemyPrefabs;
    public Transform[] enemyStations;
    public Unit[] enemyUnits;
    public Unit selectedEnemy; //for the player to choose which enemy to hits

    [Header("Buttons")]
    public Button[] enemySelectButton;
    public GameObject undoButtonHolder;

    MoveGenerator moveGenerator;
    AttackandSupplementary attackandSupplementary;
    DamageCalc damageCalc;
    PlayerandEnemyActions playerandEnemyStorage;
    BattleStats battleStats;

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
        battleStats = FindObjectOfType<BattleStats>();

        undoButtonHolder.SetActive(false);

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

            //REMOVE AFTER TESTING
            playerUnits[i].InitialiseStats();
        }
        playerHUD.SetPlayerHUD(playerUnits);
        battleStats.ShowStatsForBattle(playerUnits[currentStatsIndex].characterStats);

        enemyUnits = new EnemyUnit[enemyPrefabs.Length];
        //same for enemies
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Transform enemySpawnStation = enemyStations[i];
            GameObject enemyGObject = Instantiate(enemyPrefabs[i], enemySpawnStation);
            enemyUnits[i] = enemyGObject.GetComponent<EnemyUnit>();

            //REMOVE AFTER TESTING
            enemyUnits[i].InitialiseStats();
        }
        enemyHUD.SetEnemyHUD(enemyUnits);


        //waiting seconds after everything has instantiated to switch turns
        yield return new WaitForSeconds(1f);


        //switching turns
        state = BattleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());
    }

    public void OnNextStatsButton()
    {
        currentStatsIndex++;

        if(currentStatsIndex >= playerUnits.Length)
        {
            currentStatsIndex = 0;
        }

        battleStats.ShowStatsForBattle(playerUnits[currentStatsIndex].characterStats);
    }

    //where player can choose an action
    IEnumerator PlayerTurn()
    {
        for (int i = currentCycleIndex; i < playerUnits.Length; i++)
        {
            //checking for character defeat
            if (playerUnits[i].characterStats.CurrentHP <= 0)
            {
                //currentCycleIndex++;
                continue;
            }

            if (i > 0){undoButtonHolder.SetActive(true);} 
            else { undoButtonHolder.SetActive(false); }
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
                //if player somehow chooses an item AND a move
                moveGenerator.selectedItem = null;
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
                moveGenerator.selectedMove = null;
            }

            moveGenerator.selectedMove = null;
            moveGenerator.selectedItem = null;
            selectedPlayerUnit = null;
            selectedEnemy = null;
            attackandSupplementary.enemyPanelUI.SetActive(false);
            attackandSupplementary.allyPanelUI.SetActive(false);
            attackandSupplementary.blocker.SetActive(false);
            //incrementing in case we have to undo
            currentCycleIndex++;
            //saying the next player hasn't chosen their move yet.
            moveGenerator.ClearAttackButtons();
            undoButtonHolder.SetActive(false);
        }
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Finished.");
        //resetting the current cycle index to use again
        currentCycleIndex = 0;
        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    public void OnUndo()
    {
        if(playerandEnemyStorage.playerActionContainer.Count > 0)
        {
            playerandEnemyStorage.playerActionContainer.RemoveAt(playerandEnemyStorage.playerActionContainer.Count - 1);

            selectedPlayerUnit = null;
            selectedEnemy = null;

            //decrementing to go back to the previous character
            currentCycleIndex--;
            Debug.Log($"Move undone. {playerUnits[currentCycleIndex].characterStats.CharacterName}'s turn.");

            StartCoroutine(PlayerTurn());

        }
    }

    //picking a target ally (for Unity hierarchy)
    public void OnPlayerClick(int playerIndex)
    {
        //selecter player will be the button linked to the unit. Unit will then be chosen at the selected player to recieve buffs or heals
        selectedPlayerUnit = playerUnits[playerIndex];
    }

    //for button clicking enemies (for Unity hierarchy)
    public void OnEnemyButtonClick(int enemyIndex)
    {
        selectedEnemy = enemyUnits[enemyIndex];
    }
    void EnemyTurn()
    {
        //grabbing nondefeated players
        List<Unit> nondefeatedPlayers = playerUnits.Where(player => !player.isDefeated).ToList();

        //wait for the enemy to move
        for (int i = 0; i < enemyUnits.Length; i++)
        {
                
            if (enemyUnits[i].isDefeated)
            {
                continue;    
            }

            if (nondefeatedPlayers.Count > 0)
            {
                //getting how many enemy moves there are in the current enemy
                int enemyMoves = enemyUnits[i].characterStats.moveBaseClassList.Count;
                int playersPresent = playerUnits.Length;
                int selectedPlayer = Random.Range(0, nondefeatedPlayers.Count);
                //enemy will choosea random move in their list
                int selectedMove = Random.Range(0, enemyMoves);
                //move to use is whatever number was chosen
                MoveBaseClass moveToUse = enemyUnits[i].characterStats.moveBaseClassList[selectedMove];
                Unit unitToAttack = playerUnits[selectedPlayer];

                playerandEnemyStorage.SaveEnemyAction(enemyUnits[i], moveToUse, unitToAttack);
            }
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

        // Move player actions with healing items to the top
        List<PlayerandEnemyActions.SavePlayerActions> playerActionsWithHealingItems = new List<PlayerandEnemyActions.SavePlayerActions>();

        // Find player actions with healing items and add them to the new list
        foreach (var action in allActions)
        {
            if (action is PlayerandEnemyActions.SavePlayerActions playersAction)
            {
                if (playersAction.item != null && playersAction.item.Type == ItemType.Health)
                {
                    playerActionsWithHealingItems.Add(playersAction);
                }
            }
        }

        // Remove the player actions with healing items from the original list
        foreach (var playerAction in playerActionsWithHealingItems)
        {
            allActions.Remove(playerAction);
        }
        // Insert the player actions with healing items at the beginning of the original list
        foreach (var playerAction in playerActionsWithHealingItems)
        {
            allActions.Insert(0, playerAction);
        }


        //displaying all character actions NOTE: when using anims, yield return new WaitForSeconds(animClip.length)     
        foreach (object action in allActions)    
        {
            if (action is PlayerandEnemyActions.SavePlayerActions playerAction)
            {
                //checking if player is defeated
                if (!playerAction.playerUnit.isDefeated)
                {
                    if (playerAction.move != null)
                    {
                        damageCalc.CalcDamage(playerAction.playerUnit, playerAction.move, playerAction.theTarget);
                        //playerHUD.UpdatePlayerHPAndMP(playerAction.theTarget, playerAction.theTarget.characterStats.CurrentHP, playerAction.theTarget.characterStats.CurrentMP);
                        string message = damageCalc.message;
                        Debug.Log(message);
                        damageCalc.message = "";
                    }
                    else if (playerAction.item != null)
                    {
                        damageCalc.CalcTool(playerAction.playerUnit, playerAction.item, playerAction.theTarget);
                        //playerHUD.UpdatePlayerHPAndMP(playerAction.theTarget, playerAction.theTarget.characterStats.CurrentHP, playerAction.theTarget.characterStats.CurrentMP);
                        string message = damageCalc.message;
                        Debug.Log(message);
                        damageCalc.message = "";
                    }
                }
            }
            else if (action is PlayerandEnemyActions.SaveEnemyActions enemyAction)
            {
                if (!enemyAction.enemyUnit.isDefeated)
                {
                    damageCalc.CalcDamage(enemyAction.enemyUnit, enemyAction.move, enemyAction.theTarget);
                    //playerHUD.UpdateEnemyHPAndMP(enemyAction.theTarget, enemyAction.theTarget.characterStats.CurrentHP);
                    string message = damageCalc.message;
                    Debug.Log(message);
                    damageCalc.message = "";
                }
            }
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(2f);

        bool allEnemiesDefeated = true;
        bool allPlayersDefeated = true;

        foreach(Unit enemyUnit in enemyUnits)
        {
            //checking if all enemies are still alive
            if(enemyUnit.characterStats.CurrentHP > 0)
            {
                allEnemiesDefeated = false;
                //if even one is alive, just break since we don't need to check anymore
                break;

                //if there are all true, all enemies are defeated
            }
        }

        foreach(Unit playerUnit in playerUnits)
        {
            if(playerUnit.characterStats.CurrentHP > 0)
            {
                allPlayersDefeated = false;
                break;
            }
        }

        if (allEnemiesDefeated)
        {
            state = BattleState.WIN;
            StartCoroutine(EndBattle());
            //be sure to add drops with wins
        }
        else if (allPlayersDefeated)
        {
            state = BattleState.LOSS;
            StartCoroutine(EndBattle());
            //put them back to a pokemon center or the like. To be discussed.
        }
        else
        {
            allActions.Clear();
            sortedPlayerActions.Clear();
            sortedEnemyActions.Clear();
            playerandEnemyStorage.playerActionContainer.Clear();
            playerandEnemyStorage.enemyActionContainer.Clear();

            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }    
    }

    IEnumerator EndBattle()
    {
        foreach (Unit playerUnit in playerUnits)
        {
            playerUnit.RemoveBuffsAndDebuffs();
        }
           
        foreach (Unit enemyUnits in enemyUnits)
        {
            enemyUnits.RemoveBuffsAndDebuffs();
        }

            if (state == BattleState.WIN)
        {
            Debug.Log("Won!");
        } else if (state == BattleState.LOSS)
        {
            Debug.Log("Lost. Rerouting.");
        }
        yield return new WaitForSeconds(2f);
    }
    
}