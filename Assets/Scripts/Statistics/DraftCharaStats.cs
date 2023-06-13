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
Name
HP (Health)
Attack (Physical Attack)
Defense (Physical Defense)
Magic (Magic Attack)
Resistance (Magic Defense)
Efficiency (How Much Healing Items Will Heal)
Skill  (Critical Hit Rate)
Speed (Who Goes First)*/


    [SerializeField] TMP_Text charaNameText;
    [SerializeField] TMP_Text lvl;
    [SerializeField] TMP_Text currentHpText;
    [SerializeField] TMP_Text maxHpText;
    [SerializeField] TMP_Text currentMpText;
    [SerializeField] TMP_Text maxMpText;
    [SerializeField] TMP_Text atkText;
    [SerializeField] TMP_Text defText;
    [SerializeField] TMP_Text magText;
    [SerializeField] TMP_Text resText;
    [SerializeField] TMP_Text effText;
    [SerializeField] TMP_Text skillText;
    [SerializeField] TMP_Text speedText;
    [SerializeField] GameObject charaImageBox;

    //grabbing the stats of the characters are
    ShowStats showStats;

    CharacterStatistics characterStatistics;

    public void Start()
    {
        showStats = FindObjectOfType<ShowStats>();
        ShowStringStatsArray(showStats.charaNames);
        ShowIntStatsArray(showStats.chara1Stats);
        ShowImageStatsArray(showStats.charaImage);
        characterStatistics = FindObjectOfType<CharacterStatistics>();
        //CharacterStatisticsArray(characterStatistics.stats);
    }



    //assigning the text that's going to be shown in Unity to 
    public void ShowStringStatsArray(string[] statsArray)
    {
        charaNameText.text = statsArray[0].ToString();
    }
    
    public void ShowIntStatsArray(int[] statsArray)
    {

        lvl.text = statsArray[0].ToString();
        currentHpText.text = statsArray[1].ToString();
        maxHpText.text = statsArray[2].ToString();
        currentMpText.text = statsArray[3].ToString();
        maxMpText.text = statsArray[4].ToString();
        atkText.text = statsArray[5].ToString();
        defText.text = statsArray[6].ToString();
        magText.text = statsArray[7].ToString();
        resText.text = statsArray[8].ToString();
        effText.text = statsArray[9].ToString();
        skillText.text = statsArray[10].ToString();
        speedText.text = statsArray[11].ToString();
    }

    public void ShowImageStatsArray(Sprite[] statsArray)
    {
        charaImageBox.GetComponent<Image>().sprite = statsArray[0];
    }

    //experimantal
    public void CharacterStatisticsArray(CharacterStats[] statsArray)
    {
        charaNameText.text = statsArray[0].ToString();
        lvl.text = statsArray[1].ToString();
        currentHpText.text = statsArray[2].ToString();
        maxHpText.text = statsArray[3].ToString();
        currentMpText.text = statsArray[4].ToString();
        maxMpText.text = statsArray[5].ToString();
        atkText.text = statsArray[6].ToString();
        defText.text = statsArray[7].ToString();
        magText.text = statsArray[8].ToString();
        resText.text = statsArray[9].ToString();
        effText.text = statsArray[10].ToString();
        skillText.text = statsArray[11].ToString();
        speedText.text = statsArray[12].ToString();
    }
}
