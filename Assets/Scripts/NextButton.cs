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
    int currentIndex = 0;

    public void Start()
    {
        draftCharaStats= FindObjectOfType<DraftCharaStats>();
        draftCharaStats = GetComponent<DraftCharaStats>();
        showStats = FindObjectOfType<ShowStats>();
    }
    public void SwitchStats()
    {

        if (draftCharaStats == null)
        {
            Debug.LogError("DraftCharaStats is not initialized!");
        }

        if (showStats == null)
        {
            Debug.LogError("ShowStats is not initialized!");
        }

        //an array of character stats from the script (ShowStats)
        object[] statLoop = new object[] { showStats.chara1Stats, showStats.chara2Stats, showStats.chara3Stats, showStats.chara4Stats};

        currentIndex++;

        Debug.Log(currentIndex);
        

        if (currentIndex >= statLoop.Length)
        {
            currentIndex = 0;
        }

        //current stats equal what stat chara's stats we're currently at
        draftCharaStats.ShowStatsArray((object[])statLoop[currentIndex]);
    }
}
