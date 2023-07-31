using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackandSupplementary : MonoBehaviour
{
    //make a list for the moves
    [SerializeField] List<Button> atkButtons;
    [SerializeField] GameObject atkUI;
    [SerializeField] GameObject suppUI;
    [SerializeField] TMP_Text atkText;
    public bool actionIsUp = false;
    MoveGenerator moveGenerator;

    private void Start()
    {
        moveGenerator = FindObjectOfType<MoveGenerator>();
    }

    //for the attack button
    public void OnATKButton()
    {
        atkUI.SetActive(true);
        suppUI.SetActive(false);
        actionIsUp = true;
        moveGenerator.GenerateATKButtons();
    }
    
    //for te support button
    public void OnSUPPButton()
    {
        suppUI.SetActive(true);
        atkUI.SetActive(false);
        actionIsUp = true;
        moveGenerator.GenerateSUPPButtons();
    }

    public void OnBackButton()
    {
        if (actionIsUp == true)
        {
            suppUI.SetActive (false);
            atkUI.SetActive(false);
            actionIsUp = false;
        }
    }


}
