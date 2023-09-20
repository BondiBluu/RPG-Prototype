using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class InputDialogueNPC : MonoBehaviour
{

    [SerializeField] NPCData npcData;

    [SerializeField] int questToShow;
    [SerializeField] bool questCompleted;
    [SerializeField] bool questIsActive;
    [SerializeField] bool questAvailable;
    [SerializeField] bool dialogueStarted = false;
    bool isInTriggerZone;

    public int currentLine = 0;

    DialogueManager diaMan;


    void Start()
    {
        //referencing the DialogueManager script
        diaMan = FindObjectOfType<DialogueManager>();
        questIsActive = false;
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
            if (!diaMan.dialogActive)
            {
                StartDialogue();
            }
            else if (diaMan.dialogActive)
            {
                ContinueDialogue();
            }
        }
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
        if(currentLine < npcData.diaLines.Length)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
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
    void PreviewDialog() 
    {         
        diaMan.dialogActive = true;   
        diaMan.PreviewOn();
        diaMan.diaText.text = npcData.previewDialog;
        diaMan.nameText.text = npcData.previewName;
    }

    void ShowQuestButtons() 
    {         
        diaMan.questAcceptanceButton.gameObject.SetActive(true);   
        diaMan.questDenialButton.gameObject.SetActive(true);   
    }
    void StopShowingQuestButtons() 
    {         
        diaMan.questAcceptanceButton.gameObject.SetActive(false);
        diaMan.questDenialButton.gameObject.SetActive(false);
    }

    public void QuestAcceptance()
    {

    }

    public void QuestDenial()
    {

    }

    public IEnumerator DisplayDialogue()
    {
        for (currentLine = 0; currentLine < npcData.diaLines.Length; currentLine++)
        {
            diaMan.diaText.text = npcData.diaLines[currentLine];
            diaMan.nameText.text = npcData.nameLines[currentLine];
            diaMan.charaBox.GetComponent<Image>().sprite = npcData.charaImage[currentLine];
        }

        yield return new WaitForSeconds(0.5f);
    }
}
/*if(beginningDialogue == false)
            {
                diaMan.dialogActive = true;
                diaMan.ActiveOn();
                beginningDialogue = true;
            }
            else
            {
                //if the current line is the line where the quest button should be shown
                if(currentLine == npcData.whereQuestButtonIsShown - 1)
                {
                    ShowQuestButtons();
                }
                else 
                { 
                    StopShowingQuestButtons();
                }
                currentLine++;

                if (currentLine >= npcData.diaLines.Length)
                {
                    beginningDialogue = false;
                    diaMan.DialogOff();
                    currentLine = 0;
                }
            }
            
        }
        diaMan.diaText.text = npcData.diaLines[currentLine];
        diaMan.nameText.text = npcData.nameLines[currentLine];
        diaMan.charaBox.GetComponent<Image>().sprite = npcData.charaImage[currentLine];*/
