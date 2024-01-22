using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InputDialogueNPC : MonoBehaviour
{

    [SerializeField] NPCData npcData;

    //[SerializeField] int questToShow;
   // [SerializeField] bool questCompleted;
    //[SerializeField] bool questIsActive;
    //[SerializeField] bool questAvailable;
    //[SerializeField] bool questInquiryAccepted;
    bool questInquiryDenied = false;
    bool questInquiryAccepted = false;
    bool isInTriggerZone;

    int currentLine = 0;
    int currentQuest = 0;
    string optionChosen;

    DialogueManager diaMan;


    void Start()
    {
        //referencing the DialogueManager script
        diaMan = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Has entered");
            isInTriggerZone = true;

            //making sure the preview dialog isn't empty
            if(npcData.previewName != "" && npcData.previewDialog != "")
            {
                PreviewDialog();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Has exited");
            isInTriggerZone = false;
            EndDialogue();
        }
    }

    void OnOpenUI(InputValue value)
    {
        if (value.isPressed && isInTriggerZone)
        {
            if ( !diaMan.dialogActive && !questInquiryAccepted && !questInquiryDenied)
            {
                StartDialogue();
            }
            else if ((diaMan.dialogActive && questInquiryAccepted) || (!diaMan.dialogActive && questInquiryAccepted))
            {
                ContinueQuestDialogue();
            }
            else if ((diaMan.dialogActive && questInquiryDenied) || (!diaMan.dialogActive && questInquiryDenied))
            {
                ContinueQuestDialogue();
            }
            else if (diaMan.dialogActive)
            {
                ContinueDialogue();
            }
        }
    }

    void PreviewDialog()
    {
        diaMan.dialogActive = true;
        diaMan.PreviewOn();
        diaMan.diaText.text = npcData.previewDialog;
        diaMan.nameText.text = npcData.previewName;
    }

    void StartDialogue()
    {
        diaMan.dialogActive = true;
        diaMan.ActiveOn();
        ShowDialogue();
    }

    void ContinueDialogue()
    {
        currentLine++;
        if (currentLine < npcData.diaLines.Length)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
        }

        if (currentLine == npcData.questLine[currentQuest].whereQuestButtonIsShown)
        {
            ShowQuestButtons();
        }
        else 
        {  
            StopShowingQuestButtons();       
        }
    }

    void EndDialogue()
    {
        diaMan.dialogActive = false;
        diaMan.DialogOff();
        currentLine = 0;
    }
    void ShowDialogue()
    {
        diaMan.diaText.text = npcData.diaLines[currentLine];
        diaMan.nameText.text = npcData.nameLines[currentLine];
        diaMan.charaBox.GetComponent<Image>().sprite = npcData.charaImage[currentLine];
    }

    void ShowQuestButtons() 
    {         
        diaMan.questInquiryButton.gameObject.SetActive(true);   
        diaMan.questDisnterestButton.gameObject.SetActive(true);
        //change the text of the buttons to w/e the current quest's text is
        diaMan.questInquiryButton.GetComponentInChildren<TMP_Text>().text = npcData.questLine[currentQuest].questButtonInquiryText;
        diaMan.questDisnterestButton.GetComponentInChildren<TMP_Text>().text = npcData.questLine[currentQuest].questButtonDisinterestText;

        //add listeners to the buttons
        diaMan.questInquiryButton.onClick.AddListener(() => ShowQuestDialogue("Inquire"));
        diaMan.questDisnterestButton.onClick.AddListener(() => ShowQuestDialogue("Deny"));
    }

    void ShowQuestDialogue(string optionValue) 
    {
        currentLine = 0;
        //used to determine which dialogue to show. Global variable
        optionChosen = optionValue;
        
        StopShowingQuestButtons();

        //0 is disinterest, 1 is inquiry
        if (optionValue == "Deny")
        {
            Debug.Log("Quest Denied");
            questInquiryDenied = true;
            QuestDisinterestDialogue();
        }
        else if(optionValue == "Inquire")
        {
            Debug.Log("Quest Accepted");
            questInquiryAccepted = true;
            QuestInquiryDialogue();
        }
    }

    void ContinueQuestDialogue()
    {
        currentLine++;

        //disinterest in the quest
        if(optionChosen == "Deny")
        {
            if (currentLine < npcData.questLine[currentQuest].questDisinterestLines.Length)
            {
                QuestDisinterestDialogue();
            } 
            else 
            {
                questInquiryDenied = false;
                EndDialogue();
            }

        } //interest in the quest
        else if(optionChosen == "Inquire")
        {
            if (currentLine < npcData.questLine[currentQuest].questInquiryLines.Length)
            {
                QuestInquiryDialogue();
            } 
            else 
            {
                questInquiryAccepted = false;
                EndDialogue();
            }
        }
    }

    void QuestInquiryDialogue()
    {
        diaMan.diaText.text = npcData.questLine[currentQuest].questInquiryLines[currentLine];
        diaMan.nameText.text = npcData.questLine[currentQuest].questInquiryName[currentLine];
        diaMan.charaBox.GetComponent<Image>().sprite = npcData.questLine[currentQuest].questInquiryCharaImage[currentLine];
    }

    void QuestDisinterestDialogue()
    {
        diaMan.diaText.text = npcData.questLine[currentQuest].questDisinterestLines[currentLine];
        diaMan.nameText.text = npcData.questLine[currentQuest].questDisinterestName[currentLine];
        diaMan.charaBox.GetComponent<Image>().sprite = npcData.questLine[currentQuest].questDisinterestCharaImage[currentLine];
    }

    public void StopShowingQuestButtons() 
    {         
        diaMan.questInquiryButton.gameObject.SetActive(false);
        diaMan.questDisnterestButton.gameObject.SetActive(false);
    }

    
    public IEnumerator ItemCollected(string itemName)
    {
        diaMan.ItemShowOn();
        diaMan.itemText.text = $"You've aqcuired {itemName}.";
        yield return new WaitForSeconds(0.5f);
        diaMan.ItemShowOff();
    }
}

// public void StartQuestInquiry()
// {
//     currentLine = 0;
//     GiveQuestDialogue();
// }

// void GiveQuestDialogue() 
// {
//     diaMan.diaText.text = npcData.questLine[currentQuest].questInquiryLines[currentLine];
//     diaMan.nameText.text = npcData.questLine[currentQuest].questInquiryName[currentLine];
//     diaMan.charaBox.GetComponent<Image>().sprite = npcData.questLine[currentQuest].questInquiryCharaImage[currentLine];
// }

// void QuestAcceptanceDialogue() { }

// void QuestDenialDialogue() { }

// public void QuestAcceptance()
// {

// }

// public void QuestDenial()
// {

// }

