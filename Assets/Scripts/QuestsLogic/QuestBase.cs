using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum QuestType
{
    FETCH,
    DEFEAT,
    MESSENGER
}

public enum QuestReward
{
    NONE,
    MONEY,
    ITEMS
}

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/New Quest")]
public class QuestBase : ScriptableObject
{
    [Header("Quest General")]
    public string questTitle;
    public string questDescription;
    public string questObjective;

    [Header("Quest Text")]
    public string questButtonInquiryText;
    public string questButtonDisinterestText;

    [Header ("Inquiry")]
    public string[] questInquiryName;
    public string[] questInquiryLines;
    public Sprite[] questInquiryCharaImage;

    [Header("Acceptance")]
    public string[] questAcceptanceName;
    public string[] questAcceptanceLines;
    public Sprite[] questAcceptanceCharaImage;


    [Header("Denial")]
    public string[] questRejectionName;
    public string[] questRejectionLines;
    public Sprite[] questRejectionCharaImage;


    [Header("Quest Completion")]
    public bool questCompleted;
    public bool questActive = false;
    public QuestType questType;
    public QuestReward[] questReward;

}
