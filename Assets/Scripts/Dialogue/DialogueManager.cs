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
    public GameObject itemBox;
    public TMP_Text itemText;
    public Button questInquiryButton;
    public Button questDisnterestButton;
    public Button questAcceptanceButton; //accept
    public Button questDenialButton; //deny
    
    public Text diaText;
    public Text nameText;
    

    public bool dialogActive = false;
    public bool questInquired = false;
    public bool questAccepted = false;
    public bool questDenied = false;

    InputDialogueNPC inputDialogueNPC;
        

    void Start()
    {
        DialogOff();
        ItemShowOff();
        inputDialogueNPC = FindObjectOfType<InputDialogueNPC>();
    }

    public void ItemShowOff()
    {
        itemBox.SetActive(false);
    }

    public void ItemShowOn()
    {
        itemBox.SetActive(true);
    }

    public void DialogOff(){

        dialogActive = false;
        diaBox.SetActive(false);
        nameBox.SetActive(false);
        charaBox.SetActive(false);
        questInquiryButton.gameObject.SetActive(false);
        questDisnterestButton.gameObject.SetActive(false);
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

    public void QuestInquiry() 
    {
        //inputDialogueNPC.StartQuestInquiry();
        questInquired = true;
        //inputDialogueNPC.StopShowingQuestButtons();
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
