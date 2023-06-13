using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBattleSceneButton : MonoBehaviour
{
    [SerializeField] GameObject tabToOpen;
    public void TabOpen()
    {
        tabToOpen.SetActive(true);
    }

    public void TabClose() 
    { 
        tabToOpen.SetActive(false);
    }
}
