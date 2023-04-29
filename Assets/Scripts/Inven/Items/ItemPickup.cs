using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{

    DialogueManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<DialogueManager>();
    }

    void OnPickItem(InputValue value)
    {
        if (value.isPressed)
        {
            manager.diaBox.SetActive(true);
            manager.dialogActive= true;
            manager.diaText.text = "Found an item!";
        }

        if (value.isPressed && manager.dialogActive)
        {
            manager.diaBox.SetActive(false);
            manager.dialogActive = false;
        }
    }
}
