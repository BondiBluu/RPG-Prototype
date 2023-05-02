using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewNPC : MonoBehaviour
{

    [Header("Preview Dialogue")]

    [SerializeField] string previewDialog;
    [SerializeField] string previewName;

    DialogueManager diaMan;

    void Start()
    {
        //referencing the DialogueManager script
        diaMan = FindObjectOfType<DialogueManager>();
    }

    //showing dialogue when the player walks towards anyone holding this script
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Has entered");
            PreviewDialog();
        }
    }

    void PreviewDialog()
    {
        diaMan.dialogActive = true;
        diaMan.ActiveOn();
        diaMan.diaText.text = previewDialog;
        diaMan.nameText.text = previewName;
        diaMan.charaBox.SetActive(false);
    }
}
