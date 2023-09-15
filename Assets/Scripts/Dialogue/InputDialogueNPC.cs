using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class InputDialogueNPC : MonoBehaviour
{

    [Header("Main Dialogue")]

    [SerializeField] string[] diaLines;
    [SerializeField] string[] nameLines;
    [SerializeField] Sprite[] charaImage;
    [SerializeField] bool questIsActive;
    [SerializeField] bool questAvailable;

    [SerializeField] List<QuestBase> quests = new List<QuestBase>();

    int currentLine = 0;

    DialogueManager diaMan;

    void Start()
    {
        //referencing the DialogueManager script
        diaMan = FindObjectOfType<DialogueManager>();
        questIsActive = false;
    }

    //for the dialogue points that don't hve preview dialogue
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Has entered");
            diaMan.dialogActive = true;
        }
    }

    void OnOpenUI(InputValue value)
    {            
        if (value.isPressed && diaMan.dialogActive == true)
        {
            diaMan.dialogActive = true;
            diaMan.ActiveOn();
            currentLine++;
        }


        if (currentLine >= diaLines.Length)
        {
            diaMan.DialogOff();
            currentLine = 0;
        }

        diaMan.diaText.text = diaLines[currentLine];
        diaMan.nameText.text = nameLines[currentLine];
        diaMan.charaBox.GetComponent<Image>().sprite = charaImage[currentLine];
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        diaMan.DialogOff();
    }
}
