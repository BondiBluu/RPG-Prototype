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
    [SerializeField] public GameObject itemUI;
    [SerializeField] public GameObject statsUI;
    [SerializeField] public GameObject enemyPanelUI;
    [SerializeField] public GameObject allyPanelUI;
    [SerializeField] public GameObject blocker;
    [SerializeField] TMP_Text atkText;
    public bool wantsToAttack = false;
    public bool wantsToUseItem = false;
    public bool backButtonPressed;
    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindObjectOfType<BattleSystem>();
        blocker.SetActive(false);
    }

    //for the attack button
    public void OnATKButton()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            atkUI.SetActive(true);
            suppUI.SetActive(false);
            itemUI.SetActive(false);
            blocker.SetActive(true);
            wantsToAttack = true;
            wantsToUseItem = false;
        }
    }
      //for the item button
    public void OnItemButton()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            itemUI.SetActive(true);
            atkUI.SetActive(false);
            suppUI.SetActive(false);
            blocker.SetActive(true);
            wantsToAttack = false;
            wantsToUseItem = true;

        }
    }
    
    //for the support button
    public void OnSUPPButton()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            suppUI.SetActive(true);
            atkUI.SetActive(false);
            itemUI.SetActive(false);
            blocker.SetActive(true);
            wantsToAttack = true;
            wantsToUseItem = false;
        }
    }

    public void OnStatsButton()
    {
        statsUI.SetActive(true);
        atkUI.SetActive(false);
        itemUI.SetActive(false);
        blocker.SetActive(true);
    }

    public void EnemyContainerOn()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            suppUI.SetActive(false);
            atkUI.SetActive(false);
            itemUI.SetActive(false);
            blocker.SetActive(true);
            enemyPanelUI.SetActive(true);
        }
    }
    public void AllyContainerOn()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            suppUI.SetActive(false);
            atkUI.SetActive(false);
            itemUI.SetActive(false);
            blocker.SetActive(true);
            allyPanelUI.SetActive(true);
        }
    }

    public void TurnOffButton()
    {   
        suppUI.SetActive (false);
        allyPanelUI.SetActive (false);
        statsUI.SetActive(false);
        atkUI.SetActive(false);
        itemUI.SetActive(false);
        blocker.SetActive(false);
    }


}
