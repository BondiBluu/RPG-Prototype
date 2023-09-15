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
    [SerializeField] string questTitle;
    [SerializeField] string questDescription;
    [SerializeField] string questObjective;
    [SerializeField] string[] questDialogue;
    [SerializeField] bool questCompleted;
    [SerializeField] bool questActive;
    [SerializeField] QuestType questType;
    [SerializeField] QuestReward[] questReward;
}
