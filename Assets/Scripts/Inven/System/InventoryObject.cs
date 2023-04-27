using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    //adding the type and amount of items to the inventory
    public List<InventorySlot> Container = new List<InventorySlot>();

    //adding items to inven, the item and amount
    public void AddItem(ItemObject _item, int _amount)
    {
        
        bool hasItem = false; //assuming we don't have the item first off
        //see if we have the item in our inven in the first place
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                //add to the amount using AddAmount
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            //adding the item now and the amount of it
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
}

//when adding this class to unity, wil show up in the editor
[System.Serializable]
//inven slots that hold the items aand amount of items in said slot
public class InventorySlot
{
    //item stored in inven slot
    public ItemObject item;
    public int amount;

    //setting values when the inven slot is made
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    //adding amount to inven slot
    public void AddAmount(int value)
    {
        amount += value;
    }
}