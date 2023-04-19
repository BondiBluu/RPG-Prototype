using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuButtons : MonoBehaviour
{
    public Button iconButton;
    public bool iconUp;
    public bool menuUp = false;
    [SerializeField] Button saveButton;
    [SerializeField] Button invenButton;
    [SerializeField] Button charaButton;
    [SerializeField] GameObject saveMenu;
    public GameObject invenMenu;
    [SerializeField] GameObject charaMenu;

    // Start is called before the first frame update
    void Start()
    {
        IconOff();
    }

    //turn menu icons off
    public void IconOff()
    {
        iconUp = false;
        iconButton.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);
        invenButton.gameObject.SetActive(false);
        charaButton.gameObject.SetActive(false);
    }

    public void IconOn()
    {

        if(iconUp == false)
        {
            iconUp = true;
            saveButton.gameObject.SetActive(true);
            invenButton.gameObject.SetActive(true);
            charaButton.gameObject.SetActive(true);
        } 
        else if(iconUp == true)
        {
            IconOff();
        }
    }

    public void PullUpSave() {
        if(menuUp == false) {
            saveMenu.SetActive(true);
            menuUp = true;
        } else if (menuUp == true)
        {
            saveMenu.SetActive(false);
            menuUp = false;
        }
        
        
    }   
    
    public void PullUpInven() {
        if (menuUp == false)
        {
            invenMenu.SetActive(true);
            menuUp = true;
        } else if (menuUp == true)
        {
            invenMenu.SetActive(false);
            menuUp = false;
        }
    }   
    
    public void PullUpChara() {
        if (menuUp == false)
        {
            charaMenu.SetActive(true);
            menuUp = true;
        } else if (menuUp == true)
        {
            charaMenu.SetActive(false);
            menuUp = false;
        }
    }

    public void MenuOff()
    {
        saveMenu.SetActive(false);
        invenMenu.SetActive(false);
        charaMenu.SetActive(false);
        menuUp = false;
    }

    //turn off everything if the escape key is pressed
    void OnTurnOff(InputValue value)
    {
        if (menuUp == true && value.isPressed)
        {
            MenuOff();
        }
    }


}
