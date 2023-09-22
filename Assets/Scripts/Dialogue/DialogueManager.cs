using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject diaBox;
    public GameObject nameBox;
    public GameObject charaBox;
    
    public Text diaText;
    public Text nameText;

    [Header("For Quests")]
    public Button questAcceptanceButton;
    public Button questDenialButton;
    public TMP_Text questAcceptanceText;
    public TMP_Text questDenialText;

    public bool dialogActive = false;
    public bool questAccepted = false;
    public bool questDenied = false;

    InputDialogueNPC inputDialogueNPC;
        

    void Start()
    {
        DialogOff();
        inputDialogueNPC = FindObjectOfType<InputDialogueNPC>();
    }

    public void DialogOff(){

        dialogActive = false;
        diaBox.SetActive(false);
        nameBox.SetActive(false);
        charaBox.SetActive(false);
    }

    public void ActiveOn()
    {
        diaBox.SetActive(true);
        nameBox.SetActive(true);
        charaBox.SetActive(true);
    }
    
    public void PreviewOn()
    {
        dialogActive = false;
        diaBox.SetActive(true);
        nameBox.SetActive(true);
    }

    public void OnQuestAcceptance()
    {
        questAccepted = true;
    }

    public void OnQuestDenial()
    {
        questDenied = true;
    }

    public void PickupDialog(string dialogue)
    {
        diaBox.SetActive(true);
        diaText.text = dialogue;
    }
}
