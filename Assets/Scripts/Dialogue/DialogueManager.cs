using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject diaBox;
    public GameObject nameBox;
    public GameObject charaBox;
    
    public Text diaText;
    public Text nameText;
    

    public bool dialogActive = false;
        

    void Start()
    {
        DialogOff();
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

    public void PickupDialog(string dialogue)
    {
        diaBox.SetActive(true);
        diaText.text = dialogue;
    }
}
