using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveGenerator : MonoBehaviour
{
    [SerializeField] Transform buttonContainer;
    [SerializeField] GameObject moveButtonPrefab;
    [SerializeField] CharacterStatistics characterStatistics;
    [SerializeField] int requiredLevelToShowMove;
    [SerializeField] float buttonSpacing= 20;

    // Start is called before the first frame update
    void Start()
    {
        //spacing out the buttons
        float currentPosY = 0f;

        //if the player's level is more or equal to the required amount, show the move. Needs to be changed to add buttons when the required level is reached
        if ( characterStatistics.level >= requiredLevelToShowMove)
        {
            foreach(MoveBaseClass move in characterStatistics.moveBaseClassList)
            {
                //making a new move button- instantiating the prefab and having it be a child of buttonContainer
                GameObject buttonGO = Instantiate(moveButtonPrefab, buttonContainer);
                //setting the anchored pos of the button's rectTransform using a vector 2 
                buttonGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -currentPosY);
                //adding button spacing- next button will appear under the one that was just made
                currentPosY = buttonSpacing + buttonGO.GetComponent<RectTransform>().sizeDelta.y;
                Debug.Log("Moves available.");
                Debug.Log(move.AttackName);
                Debug.Log("Level gotten: " + move.LevelAqcuired); 
                //instantiating a button component onto the prefab, this way we won't need a button in the hierarchy
                //Button button = buttonGO.AddComponent<Button>();
                buttonGO.GetComponentInChildren<TMP_Text>().text = move.AttackName;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //pass the selected character's CharacterStatistics data to the MoveGenerator script so it can display the moves for that specific character
    public void SetCharacterData(CharacterStatistics characterData)
    {
        characterStatistics = characterData;
    }
}
