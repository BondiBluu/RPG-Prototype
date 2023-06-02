using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    string[] pickupText = new string[3];
    [SerializeField] GameObject itemBox;
    [SerializeField] Text itemText;
    public ItemObject item;
    public GameObject itemParent;
    //[SerializeField] string pickupText = "Found Item!";
    int currentLine = 0;
    public bool isInPickupRange = false;
    PlayerInven playerInven;

    void OnEnable()
    {
        // Initialize pickupText array with item-specific strings
        pickupText = new string[]
        {
            "",
            $"Found {item.itemName}!",
            $"Put {item.itemName} in bag"
        };
        Debug.Log($"Enabled {item.itemName} with pickupText: {pickupText[1]}, {pickupText[2]}");
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInven= FindObjectOfType<PlayerInven>();
    }

    //making sure the item is in range to be picked up
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("In range");
        if (other.tag == "Player")
        {
            isInPickupRange = true;
        }
    }

    
    void OnPickItem(InputValue value)
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
    }
}
