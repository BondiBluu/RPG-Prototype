using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DraftCharaStats : MonoBehaviour
{

    string charaName;
    int hp;
    int atk;
    int def;
    int mag;
    int res;
    int eff;
    int ski;
    int spe;

    /*
HP (Health)
Attack (Physical Attack)
Defense (Physical Defense)
Magic (Magic Attack)
Resistance (Magic Defense)
Efficiency (How Much Healing Items Will Heal)
Skill  (Critical Hit Rate)
Speed (Who Goes First)*/


    [SerializeField] TMP_Text charaNameText;
    [SerializeField] TMP_Text hpText;
    [SerializeField] TMP_Text atkText;
    [SerializeField] TMP_Text defText;
    [SerializeField] TMP_Text magText;
    [SerializeField] TMP_Text resText;
    [SerializeField] TMP_Text effText;
    [SerializeField] TMP_Text skillText;
    [SerializeField] TMP_Text speedText;

    //grabbing the stats of the characters are
    ShowStats showStats;


    public void Start()
    {
        showStats = FindObjectOfType<ShowStats>();
        ShowStatsArray(showStats.chara1Stats);
    }

    public void Update()
    {
    }

    public void ShowStatsArray(object[] statsArray)
    {

        charaNameText.text = statsArray[0].ToString();
        hpText.text = statsArray[1].ToString();
        atkText.text = statsArray[2].ToString();
        defText.text = statsArray[3].ToString();
        magText.text = statsArray[4].ToString();
        resText.text = statsArray[5].ToString();
        effText.text = statsArray[6].ToString();
        skillText.text = statsArray[7].ToString();
        speedText.text = statsArray[8].ToString();
    }

}
