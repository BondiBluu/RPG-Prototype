using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemPickup : MonoBehaviour
{
    //string[] pickupText = new string[3];
    //[SerializeField] GameObject itemBox;
    //[SerializeField] Text itemText;
    //public ItemObject item;
    Item itemParent;
    //public bool isInPickupRange;
    //public int currentLine = 0;
    //PlayerInven playerInven;
    //[SerializeField] string pickupText = "Found Item!";


    /*void OnEnable()
    {
        // Initialize pickupText array with item-specific strings
        pickupText = new string[]
        {
            "",
            $"Found {item.itemName}!",
            $"Put {item.itemName} in bag"
        };
        Debug.Log($"Enabled {item.itemName} with pickupText: {pickupText[1]}, {pickupText[2]}");
    }*/



    // Start is called before the first frame update
    void Start()
    {
        itemParent = FindObjectOfType<Item>();
        //playerInven= FindObjectOfType<PlayerInven>();
    }

    //making sure the item is in range to be picked up
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("In range");
            itemParent.PlayerEnteredSpace();
            //isInPickupRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Out of range");
            itemParent.PlayerLeftSpace();
            //isInPickupRange = false;
        }
    }

    /*void OnPickItem(InputValue value)
    {
        if (value.isPressed && isInPickupRange == true)
        {
            itemBox.SetActive(true);
            //currentLine++;
        }

        if (currentLine >= pickupText.Length)
        {
            itemBox.SetActive(false);
            playerInven.inven.AddItem(item, 1);
            Destroy(itemParent.gameObject);
            currentLine = 0;
        }

        itemText.text = pickupText[currentLine];
    }*/
}


/* void OnEnable()
    {
        // Initialize pickupText array with item-specific strings
        pickupText = new string[]
        {
            "",
            $"Found {item.itemName}!",
            $"Put {item.itemName} in bag"
        };
        Debug.Log($"Enabled {item.itemName} with pickupText: {pickupText[1]}, {pickupText[2]}");
    }*/


/*void OnPickItem(InputValue value)
    {
        if (value.isPressed && isInPickupRange == true)
        {
            itemBox.SetActive(true);
            currentLine++;
        }

        if (currentLine >= pickupText.Length)
        {
            itemBox.SetActive(false);
            playerInven.inven.AddItem(item, 1);
            Destroy(itemParent.gameObject);
            currentLine = 0;
        }

        itemText.text = pickupText[currentLine];
    }*/
