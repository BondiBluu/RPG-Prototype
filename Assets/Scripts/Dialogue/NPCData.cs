using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Dialog", menuName = "Dialog/New NPC Dialog")]
public class NPCData : ScriptableObject
{
    [Header("Preview Dialogue")]

    public string previewDialog;
    public string previewName;

    [Header("Main Dialogue")]
    public string[] diaLines;
    public string[] nameLines;
    public Sprite[] charaImage;

    public int whereQuestButtonIsShown;

    public List<QuestBase> questLine = new List<QuestBase>();
}
