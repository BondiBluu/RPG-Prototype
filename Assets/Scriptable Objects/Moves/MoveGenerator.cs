using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveGenerator : MonoBehaviour
{
    [SerializeField] Transform atkButtonContainer;
    [SerializeField] Transform suppButtonContainer;
    [SerializeField] GameObject moveButtonPrefab;
    [SerializeField] CharacterStatistics characterStatistics;
    [SerializeField] float buttonSpacing;

    List<MoveBaseClass> movesAlreadyAdded = new List<MoveBaseClass>();

    // Start is called before the first frame update
    void Start()
    {        
        GenerateATKButtons();
        GenerateSUPPButtons();
    }

    // Update is called once per frame
    void Update()
    {
        GenerateATKButtons();
        GenerateSUPPButtons();
    }

    public void GenerateSUPPButtons()
    {
        //spacing out the buttons
        float currentPosY = 0f;

        //if the player's level is more or equal to the required amount, show the move. Needs to be changed to add buttons when the required level is reached
        if (characterStatistics != null)
        {
            foreach (MoveBaseClass move in characterStatistics.moveBaseClassList)
            {
                //if the move's level is more than or equal to out chara's level
                if (characterStatistics.level >= move.LevelAqcuired && !movesAlreadyAdded.Contains(move) && move.MoveType == MoveType.SUPPLEMENTARY)
                    {
                    //making a new move button- instantiating the prefab and having it be a child of atkButtonContainer
                    GameObject buttonGO = Instantiate(moveButtonPrefab, suppButtonContainer);
                    //setting the anchored pos of the button's rectTransform using a vector 2 
                    buttonGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -currentPosY);
                    //adding button spacing- next button will appear under the one that was just made
                    currentPosY += buttonSpacing + buttonGO.GetComponent<RectTransform>().sizeDelta.y;
                    Debug.Log("Moves available.");
                    Debug.Log(move.AttackName);
                    Debug.Log("Level gotten: " + move.LevelAqcuired);
                    //instantiating a button component onto the prefab, this way we won't need a button in the hierarchy
                    //Button button = buttonGO.AddComponent<Button>();
                    buttonGO.GetComponentInChildren<TMP_Text>().text = move.AttackName;
                    //adding the move to the list
                    movesAlreadyAdded.Add(move);
                }
            }
        }
    }
    
    public void GenerateATKButtons()
    {
        //spacing out the buttons
        float currentPosY = 0f;

        //if the player's level is more or equal to the required amount, show the move. Needs to be changed to add buttons when the required level is reached
        if (characterStatistics != null)
        {
            foreach (MoveBaseClass move in characterStatistics.moveBaseClassList)
            {
                //if the move's level is more than or equal to out chara's level
                if (characterStatistics.level >= move.LevelAqcuired && !movesAlreadyAdded.Contains(move) && move.MoveType == MoveType.DAMAGING)
                    {
                    //making a new move button- instantiating the prefab and having it be a child of suppButtonContainer
                    GameObject buttonGO = Instantiate(moveButtonPrefab, atkButtonContainer);
                    //setting the anchored pos of the button's rectTransform using a vector 2 
                    buttonGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -currentPosY);
                    //adding button spacing- next button will appear under the one that was just made
                    currentPosY += buttonSpacing + buttonGO.GetComponent<RectTransform>().sizeDelta.y;
                    Debug.Log("Moves available.");
                    Debug.Log(move.AttackName);
                    Debug.Log("Level gotten: " + move.LevelAqcuired);
                    //instantiating a button component onto the prefab, this way we won't need a button in the hierarchy
                    //Button button = buttonGO.AddComponent<Button>();
                    buttonGO.GetComponentInChildren<TMP_Text>().text = move.AttackName;
                    //adding the move to the list
                    movesAlreadyAdded.Add(move);
                }
            }
        }
    }

    //pass the selected character's CharacterStatistics data to the MoveGenerator script so it can display the moves for that specific character
    public void SetCharacterData(CharacterStatistics characterData)
    {
        characterStatistics = characterData;
    }
}
