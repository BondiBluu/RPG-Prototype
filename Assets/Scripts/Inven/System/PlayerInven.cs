using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInven : MonoBehaviour
{
    public InventoryObject inven;
    ItemPickup item;
    //adding items to and displaying inven in the game

    // Start is called before the first frame update
    void Start()
    {
        item = FindObjectOfType<ItemPickup>();
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

    public void StopItemText()
    {
        item.itemBox.SetActive(false);
        inven.AddItem(item.item, 1);
        Destroy(item.itemParent.gameObject);
        item.currentLine = 0;
    }*/


}
