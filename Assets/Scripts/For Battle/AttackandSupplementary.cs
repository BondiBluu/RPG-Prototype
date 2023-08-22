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
    [SerializeField] public GameObject enemyPanelUI;
    [SerializeField] TMP_Text atkText;
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
        }
    }
    
    //for te support button
    public void OnSUPPButton()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            suppUI.SetActive(true);
            atkUI.SetActive(false);
        }
    }

    public void EnemyContainerOn()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            suppUI.SetActive(false);
            atkUI.SetActive(false);
            enemyPanelUI.SetActive(true);
        }
    }

    public void TurnOffButton()
    {   
            suppUI.SetActive (false);
            atkUI.SetActive(false);
    }


}
