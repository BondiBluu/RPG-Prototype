using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    string[] pickupText = new string[3];
    [SerializeField] GameObject itemBox;
    [SerializeField] Text itemText;
    public ItemObject itemObject;
    ItemPickup itemPickup;
    PlayerInven playerInven;
    Item item;
    int currentLine = 0;

    void OnEnable()
    {
        // Initialize pickupText array with item-specific strings
        pickupText = new string[]
        {
            "",
            $"Found {itemObject.itemName}!",
            $"Put {itemObject.itemName} in bag"
        };
        Debug.Log($"Enabled {itemObject.itemName} with pickupText: {pickupText[1]}, {pickupText[2]}");
    }

    // Start is called before the first frame update
    void Start()
    {
        item = FindObjectOfType<Item>();
        itemPickup = FindObjectOfType<ItemPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPickItem(InputValue value)
    {
        if (value.isPressed && itemPickup.isInPickupRange == true)
        {
            itemBox.SetActive(true);
            currentLine++;
        }

        if (currentLine >= pickupText.Length)
        {
            itemBox.SetActive(false);
            playerInven.inven.AddItem(itemObject, 1); //adding item to inven
            Destroy(item.gameObject); //destroying this object
            currentLine = 0;
        }

        itemText.text = pickupText[currentLine];
    }
}
