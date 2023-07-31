using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackandSupplementary : MonoBehaviour
{
    //make a list for the moves
    [SerializeField] List<Button> atkButtons;
    [SerializeField] List<Button> suppButtons;
    [SerializeField] GameObject atkUI;
    [SerializeField] GameObject suppUI;
    [SerializeField] TMP_Text atkText;
    [SerializeField] TMP_Text suppText;
    public bool attackIsUp;
    // Start is called before the first frame update
    void Start()
    {
        attackIsUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnATKButton()
    {
        atkUI.SetActive(true);
        attackIsUp = true;
    }

    public void OnBackButton()
    {
        if (attackIsUp == true)
        {
            atkUI.SetActive(false);
            attackIsUp = false;
        }
    }


}
