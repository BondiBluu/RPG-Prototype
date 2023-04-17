using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    MenuButtons menuButtons;

    // Start is called before the first frame update
    void Start()
    {
        menuButtons = FindObjectOfType<MenuButtons>();
    }

    //using the "esc" key to turn off all menu options
    void OnTurnOff(InputValue value)
    {
        if(menuButtons.menuUp == true && value.isPressed)
        {
            menuButtons.MenuOff();
        }
    }

    void OnOpenInventory(InputValue value) 
    {
        if (menuButtons.menuUp == false && value.isPressed)
        {
            menuButtons.PullUpInven();
        }
        else if (menuButtons.menuUp == true && value.isPressed)
        {
            menuButtons.MenuOff();
        }
    }
    void OnOpenCharacters(InputValue value) {
        if (menuButtons.menuUp == false && value.isPressed)
        {
            menuButtons.PullUpChara();
        }
        else if (menuButtons.menuUp == true && value.isPressed)
        {
            menuButtons.MenuOff();
        }
    }
    void OnOpenSave(InputValue value) {
        if (menuButtons.menuUp == false && value.isPressed)
        {
            menuButtons.PullUpSave();
        }
        else if (menuButtons.menuUp == true && value.isPressed)
        {
            menuButtons.MenuOff();
        }
    }

    void OnOpenMenu(InputValue value) {
        if (menuButtons.iconUp == false && value.isPressed)
        {
            menuButtons.iconButton.gameObject.SetActive(true);
            menuButtons.iconUp = true;
        } 
        else if (menuButtons.iconUp == true && value.isPressed)
        {
            menuButtons.IconOff();
        }
    }
}
