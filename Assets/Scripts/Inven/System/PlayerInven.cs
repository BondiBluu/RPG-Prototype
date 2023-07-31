using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInven : MonoBehaviour
{
    public InventoryObject inven;
    Item item;
    ItemPickup pickup;
    //adding items to and displaying inven in the game

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Item>();
        item = FindObjectOfType<Item>();
        pickup = FindObjectOfType<ItemPickup>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*public void FoundItemText()
    {
        item.itemBox.SetActive(true);
        item.currentLine++;
    }
    */
    public void AddingToPlayerInven()
    {
        item.itemBox.SetActive(false);
        inven.AddItem(item.itemObject, 1);
        item.currentLine = 0;
        //Destroy(pickup.itemParent.gameObject);
    }


}
