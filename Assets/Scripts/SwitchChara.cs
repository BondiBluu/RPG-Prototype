using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class SwitchChara : MonoBehaviour
{
    public GameObject switchUIBox;
    [SerializeField] bool uIOn = false;


    // Start is called before the first frame update
    void Start()
    {
        switchUIBox.SetActive(false);
    }

    //activating the "switch which characters" tab 
    void OnSwitch(InputValue value)
    {
        Debug.Log("working");
        if (uIOn == false && value.isPressed) {
            switchUIBox.SetActive(true);
            uIOn = true;
            Debug.Log("Pressed Z");
        }
    }

    public void SwitchOff()
    {
        switchUIBox.SetActive(false);
        uIOn = false;
    }


}
