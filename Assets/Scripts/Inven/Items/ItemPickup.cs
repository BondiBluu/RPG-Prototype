using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    //[SerializeField] string[] pickupText;
    [SerializeField] string pickupText = "Found Item!";
    int currentLine = 0;
    bool isInPickupRange = false;
    DialogueManager diaMan;


    // Start is called before the first frame update
    void Start()
    {
        diaMan = FindObjectOfType<DialogueManager>();
    }

    //making sure the item is in range to be picked up
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInPickupRange = true;
            Debug.Log("In pickup range");
        }
    }

    
    void OnPickItem(InputValue value)
    {
        if (value.isPressed && isInPickupRange == true)
        {
            Debug.Log("is picked");
            diaMan.diaBox.SetActive(true);
            diaMan.diaText.text = pickupText; 
            currentLine++;
        }

        if (currentLine >= 2)
        {
            diaMan.diaBox.SetActive(false);
            currentLine = 0;
        }
    }
}
