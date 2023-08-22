using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackandSupplementary : MonoBehaviour
{
    //make a list for the moves
    [SerializeField] List<Button> atkButtons;
    [SerializeField] public GameObject atkUI;
    [SerializeField] public GameObject suppUI;
    [SerializeField] TMP_Text atkText;
    public bool actionIsUp = false;
    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
    }

    //for the attack button
    public void OnATKButton()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            atkUI.SetActive(true);
            suppUI.SetActive(false);
            actionIsUp = true;
        }
    }
    
    //for te support button
    public void OnSUPPButton()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            suppUI.SetActive(true);
            atkUI.SetActive(false);
            actionIsUp = true;
        }
    }

    public void TurnOffButton()
    {   
            suppUI.SetActive (false);
            atkUI.SetActive(false);
            actionIsUp = false;
    }


}
