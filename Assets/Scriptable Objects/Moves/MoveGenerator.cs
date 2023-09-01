using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveGenerator : MonoBehaviour
{
    [SerializeField] Transform atkButtonContainer;
    [SerializeField] Transform suppButtonContainer;
    [SerializeField] Transform itemButtonContainer;
    [SerializeField] GameObject moveButtonPrefab;
    [SerializeField] float buttonSpacing;
    BattleSystem battleSystem;
    AttackandSupplementary attackandSupplementary;
    public InventoryObject playerInven;


    bool attackButtonPressed = false;
    public MoveBaseClass selectedMove;
    public ItemObject selectedItem;

    List<MoveBaseClass> movesAlreadyAdded = new List<MoveBaseClass>();

    // Start is called before the first frame update
    void Start()
    {        
        battleSystem = FindObjectOfType<BattleSystem>();
        attackandSupplementary = FindObjectOfType<AttackandSupplementary>();
    }

    public void GenerateSUPPButtons(CharacterStatistics characterStatistics)
    {
        movesAlreadyAdded.Clear();
        foreach (Transform button in suppButtonContainer)
        {
            Destroy(button.gameObject);
        }

        //spacing out the buttons
        float currentPosY = 0f;

        //if the player's level is more or equal to the required amount, show the move. Needs to be changed to add buttons when the required level is reached
        if (characterStatistics != null)
        {
            for (int i = 0; i < characterStatistics.moveBaseClassList.Count; i++)
            {
                //getting the specific move from characterStats
                MoveBaseClass move = characterStatistics.moveBaseClassList[i];

                //if the move's level is more than or equal to out chara's level
                if (characterStatistics.Level >= move.LevelAqcuired && !movesAlreadyAdded.Contains(move) && move.MoveType == MoveType.SUPPLEMENTARY)
                    {
                    //making a new move button- instantiating the prefab and having it be a child of atkButtonContainer
                    GameObject buttonGO = Instantiate(moveButtonPrefab, suppButtonContainer);
                    //setting the anchored pos of the button's rectTransform using a vector 2 
                    buttonGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -currentPosY);
                    //adding button spacing- next button will appear under the one that was just made
                    currentPosY += buttonSpacing + buttonGO.GetComponent<RectTransform>().sizeDelta.y;
                    
                    buttonGO.GetComponentInChildren<TMP_Text>().text = move.AttackName;
                    //adding the move to the list
                    movesAlreadyAdded.Add(move);

                    //prefabs can't have onClick events, so we'll have to get the component and add an onClick event.
                    Button buttonComponent = buttonGO.GetComponent<Button>();
                    buttonComponent.onClick.AddListener(() => OnAttackButton(move, i)); 

                }
            }
        }
    }
    
    public void GenerateATKButtons(CharacterStatistics characterStatistics)
    {
        movesAlreadyAdded.Clear();
        foreach (Transform button in atkButtonContainer)
        {
            Destroy(button.gameObject);
        }

        float currentPosY = 0f;

        if (characterStatistics != null)
        {
            for (int i = 0; i < characterStatistics.moveBaseClassList.Count; i++)
            {
                MoveBaseClass move = characterStatistics.moveBaseClassList[i];

                if (characterStatistics.Level >= move.LevelAqcuired && !movesAlreadyAdded.Contains(move) && move.MoveType == MoveType.DAMAGING)
                    {
                    GameObject buttonGO = Instantiate(moveButtonPrefab, atkButtonContainer);

                    buttonGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -currentPosY);

                    currentPosY += buttonSpacing + buttonGO.GetComponent<RectTransform>().sizeDelta.y;

                    buttonGO.GetComponentInChildren<TMP_Text>().text = move.AttackName;

                    movesAlreadyAdded.Add(move);

                    Button buttonComponent = buttonGO.GetComponent<Button>();
                    buttonComponent.onClick.AddListener(() => OnAttackButton(move,i));
                }
            }
        }
    }

    public void GenerateItems()
    {
        foreach (Transform button in itemButtonContainer)
        {
            Destroy(button.gameObject);
        }

        float currentPosY = 0f;

        for (int i = 0; i < playerInven.Container.Count; i++)
        {
            //grabbing the specific inven item in the inven's container
            InventorySlot slot = playerInven.Container[i];
            //grabbiing the specific item in the slot we made
            ItemObject item = slot.item;
            if (item.Type == ItemType.Health || item.Type == ItemType.DamagingTool)
            {
                GameObject buttonGo = Instantiate(moveButtonPrefab, itemButtonContainer);
                buttonGo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -currentPosY);

                currentPosY += buttonSpacing + buttonGo.GetComponent<RectTransform>().sizeDelta.y;

                buttonGo.GetComponentInChildren<TMP_Text>().text = item.InvenItemName + " x" + slot.amount;

                Button buttonComponent = buttonGo.GetComponent<Button>();
                buttonComponent.onClick.AddListener(() => OnItemButton(item, i));
            }
        }
    }

    //checking if the attack button's been pressed
    public bool HasPressedAttackButton()
    {
        return attackButtonPressed;
    }

    //clears the flag that signals when the player has made their move
    public void ClearAttackButtons()
    {
        attackButtonPressed = false;
    }

    //using the generated buttons to attack. parameters are the move being used and the current player using it
    public void OnAttackButton(MoveBaseClass move, int playerIndex)
    { 

        if (battleSystem.state != BattleState.PLAYERTURN)
        {
            return;
        }

        selectedMove = move;
        attackButtonPressed = true;
        attackandSupplementary.TurnOffButton();
    }

    void OnItemButton(ItemObject item, int playerIndex)
    {
        if (battleSystem.state != BattleState.PLAYERTURN)
        {
            return;
        }

        selectedItem = item;
        attackButtonPressed = true;
        attackandSupplementary.TurnOffButton();
    }
}
