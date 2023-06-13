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
        showStats = FindObjectOfType<ShowStats>();
    }
    public void SwitchStats()
    {
        //an array of character stats from the script (ShowStats)
        Array[] statLoop = new Array[] { showStats.chara1Stats, showStats.chara2Stats, showStats.chara3Stats, showStats.chara4Stats };
        currentIndex++;

        Debug.Log(currentIndex);
        

        if (currentIndex >= statLoop.Length)
        {
            currentIndex = 0;
        }

        //an array of character names and character images from the script (ShowStats)
        string[] stringLoop = new string[] { showStats.charaNames[currentIndex] };
        Sprite[] imageLoop = new Sprite[] { showStats.charaImage[currentIndex] };

        //current stats equal what stat chara's stats we're currently at
        draftCharaStats.ShowStringStatsArray(stringLoop);
        draftCharaStats.ShowIntStatsArray((int[])statLoop[currentIndex]);
        draftCharaStats.ShowImageStatsArray(imageLoop);
    }
}
