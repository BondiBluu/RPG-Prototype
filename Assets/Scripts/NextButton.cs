using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] Button nextButton;

    DraftCharaStats draftCharaStats;
    ShowStats showStats;
    object[] currentStats;

    public void Start()
    {
        draftCharaStats= FindObjectOfType<DraftCharaStats>();
        showStats= FindObjectOfType<ShowStats>();
        currentStats = showStats.chara1Stats;
    }
    public void SwitchStats()
    {
        //an array of character stats from the script (ShowStats)
        object[] statLoop = new object[] { showStats.chara1Stats, showStats.chara2Stats, showStats.chara3Stats, showStats.chara4Stats};

        for (int i = 0; i < statLoop.Length; i++)
        {
            //current stats equal what stat chara's stats we're currently at
            currentStats = (object[])statLoop[i];

            draftCharaStats.ShowStatsArray(currentStats);

            if(i >= statLoop.Length - 1) 
            {
                i = 0;
            }
        }
    }
}
