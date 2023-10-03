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
    public string[] nPCQuestName;
    public string[] nPCQuestDialogue;

    [Header("Quest Text")]
    public string questButtonInquiryText;
    public string questButtonDisinterestText;

    [Header("Acceptance")]
    public string[] questAcceptanceName;
    public string[] questAcceptanceLines;

    [Header("Denial")]
    public string[] questRejectionName;
    public string[] questRejectionLines;

    [Header("Quest Completion")]
    public bool questCompleted;
    public bool questActive;
    public QuestType questType;
    public QuestReward[] questReward;

}
