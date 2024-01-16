using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool itemCanBePicked;
    GameObject itemToCollect;
    public string itemCollectedName;

    [SerializeField] List<QuestBase> quests = new List<QuestBase>();
    DialogueManager manager;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>(); 
        if (item)
        {
            itemCanBePicked = true;
            itemToCollect = other.gameObject;
            Debug.Log("Item can be picked");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            itemCanBePicked = false;
            itemToCollect = null;
            Debug.Log("Item can't be picked");
        }
    }

    void OnCollect(InputValue value)
    {
        if (itemCanBePicked)
        {
            if(value.isPressed && itemCanBePicked)
            {
                itemCollectedName = itemToCollect.GetComponent<Item>().item.name;
            }
        }
    }


}
