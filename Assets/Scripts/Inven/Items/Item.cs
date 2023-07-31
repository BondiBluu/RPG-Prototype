using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    string[] pickupText = new string[2];
    [SerializeField] public  GameObject itemBox;
    [SerializeField] Text itemText;
    public ItemObject itemObject;
    PlayerInven playerInven;
    public int currentLine = 0;
    public bool playerEnteredSpace;
    [SerializeField] string objectname;



    // Start is called before the first frame update
    void Start()
    {
        playerInven = FindObjectOfType<PlayerInven>();
        playerEnteredSpace = false;
        
    }

    //for ItemPickup.cs
    public void PlayerEnteredSpace()
    {
        playerEnteredSpace = true;
        Debug.Log("Item.cs has registered that player has entered item range.");
    }

    //for ItemPickup.cs
    public void PlayerLeftSpace()
    {
        playerEnteredSpace = false;
        Debug.Log("Player left.");
    }

    void OnPickItem(InputValue value)
    {
        if (value.isPressed && playerEnteredSpace == true)
        {
                // Access itemObject or perform operations on it
                Debug.Log("Button was pressed");
                itemBox.SetActive(true);
                currentLine++;

        }

        if (currentLine > pickupText.Length - 1 && playerEnteredSpace == true)
        {
            itemBox.SetActive(false);
            playerInven.AddingToPlayerInven();
            //playerInven.inven.AddItem(itemObject, 1); //adding item to inven
            Destroy(gameObject); //destroying this object
        }

        itemText.text = pickupText[currentLine];
    }
}
