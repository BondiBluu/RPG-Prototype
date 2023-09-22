using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Dialog", menuName = "Dialog/New Dialog")]
public class NPCData : ScriptableObject
{
    [Header("Preview Dialogue")]

    public string previewDialog;
    public string previewName;

    [Header("Main Dialogue")]
    public string[] diaLines;
    public string[] nameLines;
    public Sprite[] charaImage;

    [Header("Quest Dialogue")]
    public string[] questNameLines;
    public Sprite[] questCharaImage;


    [Header("Quest Buttons")]
    public string questAcceptanceText;
    public string questDenialText;
    public string[] questDiaLines;
    public string[] rejectionLines;

    public int whereQuestButtonIsShown;

    public List<QuestBase> questLine = new List<QuestBase>();
}
