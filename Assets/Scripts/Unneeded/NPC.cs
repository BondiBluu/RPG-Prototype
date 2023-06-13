using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    [Header("Preview Dialogue")]

    [SerializeField] string previewDialog;
    [SerializeField] string previewName;

    [Header("Main Dialogue")]

    [SerializeField] string[] diaLines;
    [SerializeField] string[] nameLines;
    [SerializeField] Sprite[] charaImage;

    int currentLine = 0;

    DialogueManager diaMan;
    void Start()
    {
        //referencing the DialogueManager script
        diaMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DialogOn();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PreviewDialog();
        }
    }

    void PreviewDialog()
    {
        diaMan.dialogActive = true;
        diaMan.ActiveOn();
        diaMan.diaText.text = previewDialog;
        diaMan.nameText.text = previewName;
    }

    public void DialogOn()
    {
        if (Input.GetKeyDown(KeyCode.Space) && diaMan.dialogActive == true)
        {
            diaMan.dialogActive = true;
            diaMan.ActiveOn();
        }

        if (Input.GetKeyDown(KeyCode.Space) && diaMan.dialogActive)
        {
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
