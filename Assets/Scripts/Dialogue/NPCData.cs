using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Dialog", menuName = "Dialog/New NPC Dialog")]
public class NPCData : ScriptableObject
{
    [Header("Preview Dialogue")]

    public string previewName;
    public string previewDialog;

    [Header("Main Dialogue")]
    public string[] nameLines;
    public string[] diaLines;
    public Sprite[] charaImage;

    public List<QuestBase> questLine = new List<QuestBase>();
}
